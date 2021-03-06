/// <summary> The contents of this file are subject to the Mozilla Public License Version 1.1
/// (the "License"); you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/
/// Software distributed under the License is distributed on an "AS IS" basis,
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
/// specific language governing rights and limitations under the License.
/// 
/// The Original Code is "XMLParser.java".  Description:
/// "Parses and encodes HL7 messages in XML form, according to HL7's normative XML encoding
/// specification."
/// 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C)
/// 2002.  All Rights Reserved.
/// 
/// Contributor(s): ______________________________________.
/// 
/// Alternatively, the contents of this file may be used under the terms of the
/// GNU General Public License (the  �GPL�), in which case the provisions of the GPL are
/// applicable instead of those above.  If you wish to allow use of your version of this
/// file only under the terms of the GPL and not to allow others to use your version
/// of this file under the MPL, indicate your decision by deleting  the provisions above
/// and replace  them with the notice and other provisions required by the GPL License.
/// If you do not delete the provisions above, a recipient may use your version of
/// this file under either the MPL or the GPL.
/// </summary>

namespace NHapi.Base.Parser
{
    using System;

    using NHapi.Base.Log;
    using NHapi.Base.Model;
    using NHapi.Base.Util;

    /// <summary>
    /// Parses and encodes HL7 messages in XML form, according to HL7's normative XML encoding
    /// specification.  This is an abstract class that handles datatype and segment parsing/encoding,
    /// but not the parsing/encoding of entire messages.  To use the XML parser, you should create a
    /// subclass for a certain message structure.  This subclass must be able to identify the Segment
    /// objects that correspond to various Segment nodes in an XML document, and call the methods
    /// <code>
    /// parse(Segment segment, ElementNode segmentNode)</code> and <code>encode(Segment segment, ElementNode segmentNode)
    /// </code> as appropriate.  XMLParser uses the Xerces parser, which must be installed in your
    /// classpath.
    /// </summary>

    public abstract class XMLParser : ParserBase
    {
        #region Static Fields

        /// <summary>   The log. </summary>
        private static readonly IHapiLog log;

        #endregion

        #region Fields

        /// <summary>   All keepAsOriginalNodes names, concatenated by a pipe (|) </summary>
        private System.String concatKeepAsOriginalNodes = "";

        /// <summary>
        /// The nodes whose names match these strings will be kept as original, meaning that no white
        /// space treaming will occur on them.
        /// </summary>

        private System.String[] keepAsOriginalNodes;

        /// <summary>   The parser. </summary>
        private System.Xml.XmlDocument parser;

        #endregion

        #region Constructors and Destructors

        /// <summary>   Initializes static members of the XMLParser class. </summary>
        static XMLParser()
        {
            log = HapiLogFactory.GetHapiLog(typeof(XMLParser));
        }

        /// <summary>   Initializes a new instance of the XMLParser class. </summary>
        public XMLParser()
        {
            this.parser = new System.Xml.XmlDocument();
            this.parser.PreserveWhitespace = false; // this may not be similar functionality.
        }

        /// <summary>   Initializes a new instance of the XMLParser class. </summary>
        ///
        /// <param name="factory">  The factory. </param>

        public XMLParser(IModelClassFactory factory)
            : base(factory)
        {
            this.parser = new System.Xml.XmlDocument();
            this.parser.PreserveWhitespace = false; // this may not be similar functionality.
        }

        #endregion

        #region Public Properties

        /// <summary>   Gets the default encoding. </summary>
        ///
        /// <value> the preferred encoding of this Parser. </value>

        public override System.String DefaultEncoding
        {
            get
            {
                return "XML";
            }
        }

        /// <summary>   Gets or sets the &lt;i&gt;keepAsOriginalNodes&lt;i&gt; </summary>
        /// <summary>   Sets the &lt;i&gt;keepAsOriginalNodes&lt;i&gt;
        ///             
        ///             The nodes whose names match the &lt;i&gt;keepAsOriginalNodes&lt;i&gt; will be
        ///             kept as original, meaning that no white space treaming will occur on them. </summary>
        ///
        /// <value> The keep as original nodes. </value>

        public virtual System.String[] KeepAsOriginalNodes
        {
            get
            {
                return this.keepAsOriginalNodes;
            }

            set
            {
                this.keepAsOriginalNodes = value;

                if (value.Length != 0)
                {
                    //initializes the         
                    System.Text.StringBuilder strBuf = new System.Text.StringBuilder(value[0]);
                    for (int i = 1; i < value.Length; i++)
                    {
                        strBuf.Append("|");
                        strBuf.Append(value[i]);
                    }
                    this.concatKeepAsOriginalNodes = strBuf.ToString();
                }
                else
                {
                    this.concatKeepAsOriginalNodes = "";
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>   Test harness. </summary>
        ///
        /// <param name="args"> Array of command-line argument strings. </param>

        [STAThread]
        public static void Main(System.String[] args)
        {
            if (args.Length != 1)
            {
                System.Console.Out.WriteLine("Usage: XMLParser pipe_encoded_file");
                System.Environment.Exit(1);
            }

            //read and parse message from file 
            try
            {
                PipeParser parser = new PipeParser();
                System.IO.FileInfo messageFile = new System.IO.FileInfo(args[0]);
                long fileLength = SupportClass.FileLength(messageFile);
                System.IO.StreamReader r = new System.IO.StreamReader(
                    messageFile.FullName,
                    System.Text.Encoding.Default);
                char[] cbuf = new char[(int)fileLength];
                System.Console.Out.WriteLine(
                    "Reading message file ... " + r.Read(cbuf, 0, cbuf.Length) + " of " + fileLength + " chars");
                r.Close();
                System.String messString = System.Convert.ToString(cbuf);
                IMessage mess = parser.Parse(messString);
                System.Console.Out.WriteLine("Got message of type " + mess.GetType().FullName);

                NHapi.Base.Parser.XMLParser xp = new AnonymousClassXMLParser();

                //loop through segment children of message, encode, print to console
                System.String[] structNames = mess.Names;
                for (int i = 0; i < structNames.Length; i++)
                {
                    IStructure[] reps = mess.GetAll(structNames[i]);
                    for (int j = 0; j < reps.Length; j++)
                    {
                        if (typeof(ISegment).IsAssignableFrom(reps[j].GetType()))
                        {
                            //ignore groups
                            System.Xml.XmlDocument docBuilder = new System.Xml.XmlDocument();
                            System.Xml.XmlDocument doc = new System.Xml.XmlDocument(); //new doc for each segment
                            System.Xml.XmlElement root = doc.CreateElement(reps[j].GetType().FullName);
                            doc.AppendChild(root);
                            xp.Encode((ISegment)reps[j], root);
                            System.IO.StringWriter out_Renamed = new System.IO.StringWriter();
                            System.Console.Out.WriteLine(
                                "Segment " + reps[j].GetType().FullName + ": \r\n" + doc.OuterXml);

                            System.Type[] segmentConstructTypes = { typeof(IMessage) };
                            System.Object[] segmentConstructArgs = { null };
                            ISegment s =
                                (ISegment)
                                    reps[j].GetType().GetConstructor(segmentConstructTypes).Invoke(segmentConstructArgs);
                            xp.Parse(s, root);
                            System.Xml.XmlDocument doc2 = new System.Xml.XmlDocument();
                            System.Xml.XmlElement root2 = doc2.CreateElement(s.GetType().FullName);
                            doc2.AppendChild(root2);
                            xp.Encode(s, root2);
                            System.IO.StringWriter out2 = new System.IO.StringWriter();
                            System.Xml.XmlWriter ser = System.Xml.XmlWriter.Create(out2);
                            doc.WriteTo(ser);
                            if (out2.ToString().Equals(out_Renamed.ToString()))
                            {
                                System.Console.Out.WriteLine("Re-encode OK");
                            }
                            else
                            {
                                System.Console.Out.WriteLine(
                                    "Warning: XML different after parse and re-encode: \r\n" + out2);
                            }
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                SupportClass.WriteStackTrace(e, Console.Error);
            }
        }

        /// <summary>
        /// Populates the given Element with data from the given Segment, by inserting Elements
        /// corresponding to the Segment's fields, their components, etc.  Returns true if there is at
        /// least one data value in the segment.
        /// </summary>
        ///
        /// <exception cref="HL7Exception"> Thrown when a HL 7 error condition occurs. </exception>
        ///
        /// <param name="segmentObject">    The segment object. </param>
        /// <param name="segmentElement">   Element describing the segment. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        public virtual bool Encode(ISegment segmentObject, System.Xml.XmlElement segmentElement)
        {
            bool hasValue = false;
            int n = segmentObject.NumFields();
            for (int i = 1; i <= n; i++)
            {
                System.String name = MakeElementName(segmentObject, i);
                IType[] reps = segmentObject.GetField(i);
                for (int j = 0; j < reps.Length; j++)
                {
                    System.Xml.XmlElement newNode = segmentElement.OwnerDocument.CreateElement(name);
                    bool componentHasValue = Encode(reps[j], newNode);
                    if (componentHasValue)
                    {
                        try
                        {
                            segmentElement.AppendChild(newNode);
                        }
                        catch (System.Exception e)
                        {
                            throw new HL7Exception(
                                "DOMException encoding Segment: ",
                                HL7Exception.APPLICATION_INTERNAL_ERROR,
                                e);
                        }
                        hasValue = true;
                    }
                }
            }
            return hasValue;
        }

        /// <summary>
        /// <p>Creates an XML Document that corresponds to the given Message object. </p>
        /// <p>If you are implementing this method, you should create an XML Document, and insert XML
        /// Elements
        /// into it that correspond to the groups and segments that belong to the message type that your
        /// subclass of XMLParser supports.  Then, for each segment in the message, call the method
        /// <code>encode(Segment segmentObject, Element segmentElement)</code> using the Element for
        /// that segment and the corresponding Segment object from the given Message.</p>
        /// </summary>
        ///
        /// <param name="source">   a Message object from which to construct an encoded message string. </param>
        ///
        /// <returns>   A System.Xml.XmlDocument. </returns>

        public abstract System.Xml.XmlDocument EncodeDocument(IMessage source);

        /// <summary>
        /// For response messages, returns the value of MSA-2 (the message ID of the message sent by the
        /// sending system).  This value may be needed prior to main message parsing, so that
        /// (particularly in a multi-threaded scenario) the message can be routed to the thread that sent
        /// the request.  We need this information first so that any parse exceptions are thrown to the
        /// correct thread.  Implementers of Parsers should take care to make the implementation of this
        /// method very fast and robust. Returns null if MSA-2 can not be found (e.g. if the message is
        /// not a response message).  Trims whitespace from around the MSA-2 field.  
        /// </summary>
        ///
        /// <param name="message">  a String that contains an HL7 message. </param>
        ///
        /// <returns>   The acknowledge identifier. </returns>

        public override System.String GetAckID(System.String message)
        {
            System.String ackID = null;
            try
            {
                ackID = this.ParseLeaf(message, "msa.2", 0).Trim();
            }
            catch (HL7Exception)
            {
                /* OK ... assume it isn't a response message */
            }
            return ackID;
        }

        /// <summary>
        /// <p>Returns a minimal amount of data from a message string, including only the data needed to
        /// send a response to the remote system.  This includes the following fields:
        /// <ul><li>field separator</li>
        /// <li>encoding characters</li>
        /// <li>processing ID</li>
        /// <li>message control ID</li></ul>
        /// This method is intended for use when there is an error parsing a message, (so the Message
        /// object is unavailable) but an error message must be sent back to the remote system including
        /// some of the information in the inbound message.  This method parses only that required
        /// information, hopefully avoiding the condition that caused the original error.</p>
        /// </summary>
        ///
        /// <param name="message">  a String that contains an HL7 message. </param>
        ///
        /// <returns>   The critical response data. </returns>

        public override ISegment GetCriticalResponseData(System.String message)
        {
            System.String version = this.GetVersion(message);
            ISegment criticalData = ParserBase.MakeControlMSH(version, this.Factory);

            Terser.Set(criticalData, 1, 0, 1, 1, this.ParseLeaf(message, "MSH.1", 0));
            Terser.Set(criticalData, 2, 0, 1, 1, this.ParseLeaf(message, "MSH.2", 0));
            Terser.Set(criticalData, 10, 0, 1, 1, this.ParseLeaf(message, "MSH.10", 0));
            System.String procID = this.ParseLeaf(message, "MSH.11", 0);
            if (procID == null || procID.Length == 0)
            {
                procID = this.ParseLeaf(message, "PT.1", message.IndexOf("MSH.11"));
                //this field is a composite in later versions
            }
            Terser.Set(criticalData, 11, 0, 1, 1, procID);

            return criticalData;
        }

        /// <summary>
        /// Returns a String representing the encoding of the given message, if the encoding is
        /// recognized.  For example if the given message appears to be encoded using HL7 2.x XML rules
        /// then "XML" would be returned. If the encoding is not recognized then null is returned.  That
        /// this method returns a specific encoding does not guarantee that the message is correctly
        /// encoded (e.g. well formed XML) - just that it is not encoded using any other encoding than
        /// the one returned. Returns null if the encoding is not recognized.
        /// </summary>
        ///
        /// <param name="message">  a String that contains an HL7 message. </param>
        ///
        /// <returns>   The encoding. </returns>

        public override System.String GetEncoding(System.String message)
        {
            System.String encoding = null;

            //check for a number of expected strings 
            System.String[] expected = { "<MSH.1", "<MSH.2", "</MSH>" };
            bool isXML = true;
            for (int i = 0; i < expected.Length; i++)
            {
                if (message.IndexOf(expected[i]) < 0)
                {
                    isXML = false;
                }
            }
            if (isXML)
            {
                encoding = "XML";
            }

            return encoding;
        }

        /// <summary>
        /// Returns the version ID (MSH-12) from the given message, without fully parsing the message.
        /// The version is needed prior to parsing in order to determine the message class into which the
        /// text of the message should be parsed.
        /// </summary>
        ///
        /// <param name="message">  a String that contains an HL7 message. </param>
        ///
        /// <returns>   The version. </returns>

        public override System.String GetVersion(System.String message)
        {
            System.String version = this.ParseLeaf(message, "MSH.12", 0);
            if (version == null || version.Trim().Length == 0)
            {
                version = this.ParseLeaf(message, "VID.1", message.IndexOf("MSH.12"));
            }
            return version;
        }

        /// <summary>   Populates the given Segment object with data from the given XML Element. </summary>
        /// <summary>   for the given Segment, or if there is an error while setting individual field
        ///             values. </summary>
        ///
        /// <param name="segmentObject">    The segment object. </param>
        /// <param name="segmentElement">   Element describing the segment. </param>

        public virtual void Parse(ISegment segmentObject, System.Xml.XmlElement segmentElement)
        {
            SupportClass.HashSetSupport done = new SupportClass.HashSetSupport();

            //        for (int i = 1; i <= segmentObject.NumFields(); i++) {
            //            String elementName = makeElementName(segmentObject, i);
            //            done.add(elementName);
            //            parseReps(segmentObject, segmentElement, elementName, i);
            //        }

            System.Xml.XmlNodeList all = segmentElement.ChildNodes;
            for (int i = 0; i < all.Count; i++)
            {
                System.String elementName = all.Item(i).Name;
                if (System.Convert.ToInt16(all.Item(i).NodeType) == (short)System.Xml.XmlNodeType.Element
                    && !done.Contains(elementName))
                {
                    done.Add(elementName);

                    int index = elementName.IndexOf('.');
                    if (index >= 0 && elementName.Length > index)
                    {
                        //properly formatted element
                        System.String fieldNumString = elementName.Substring(index + 1);
                        int fieldNum = System.Int32.Parse(fieldNumString);
                        this.ParseReps(segmentObject, segmentElement, elementName, fieldNum);
                    }
                    else
                    {
                        log.Debug(
                            "Child of segment " + segmentObject.GetStructureName() + " doesn't look like a field: "
                            + elementName);
                    }
                }
            }

            //set data type of OBX-5        
            if (segmentObject.GetType().FullName.IndexOf("OBX") >= 0)
            {
                Varies.fixOBX5(segmentObject, this.Factory);
            }
        }

        /// <summary>   Populates the given Type object with data from the given XML Element. </summary>
        ///
        /// <param name="datatypeObject">   The datatype object. </param>
        /// <param name="datatypeElement">  Element describing the datatype. </param>

        public virtual void Parse(IType datatypeObject, System.Xml.XmlElement datatypeElement)
        {
            if (datatypeObject is Varies)
            {
                this.ParseVaries((Varies)datatypeObject, datatypeElement);
            }
            else if (datatypeObject is IPrimitive)
            {
                this.ParsePrimitive((IPrimitive)datatypeObject, datatypeElement);
            }
            else if (datatypeObject is IComposite)
            {
                this.ParseComposite((IComposite)datatypeObject, datatypeElement);
            }
        }

        /// <summary>
        /// <p>Creates and populates a Message object from an XML Document that contains an XML-encoded
        /// HL7 message.</p>
        /// <p>The easiest way to implement this method for a particular message structure is as follows:
        /// <ol><li>Create an instance of the Message type you are going to handle with your subclass
        /// of XMLParser</li>
        /// <li>Go through the given Document and find the Elements that represent the top level of
        /// each message segment. </li>
        /// <li>For each of these segments, call <code>parse(Segment segmentObject, Element
        /// segmentElement)</code>,
        /// providing the appropriate Segment from your Message object, and the corresponding
        /// Element.</li></ol>
        /// At the end of this process, your Message object should be populated with data from the XML
        /// Document.</p>
        /// </summary>
        ///
        /// <summary>   is not supported by this parser. </summary>
        ///
        /// <param name="XMLMessage">   Message describing the XML. </param>
        /// <param name="version">      the name of the HL7 version to which the message belongs (eg
        ///                             "2.5") </param>
        ///
        /// <returns>   An IMessage. </returns>

        public abstract IMessage ParseDocument(System.Xml.XmlDocument XMLMessage, System.String version);

        /// <summary>
        /// Returns true if and only if the given encoding is supported by this Parser.
        /// </summary>
        ///
        /// <param name="encoding"> the name of the HL7 encoding to use (eg "XML"; most implementations
        ///                         support only  
        ///                         one encoding) </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        public override bool SupportsEncoding(System.String encoding)
        {
            if (encoding.Equals("XML"))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Methods

        /// <summary>   Formats a Message object into an HL7 message string using the given encoding. </summary>
        /// <summary>   (e.g. required fields are null) </summary>
        /// <summary>   supported by this parser. </summary>
        ///
        /// <exception cref="EncodingNotSupportedException">    Thrown when an Encoding Not Supported
        ///                                                     error condition occurs. </exception>
        ///
        /// <param name="source">   a Message object from which to construct an encoded message string. </param>
        /// <param name="encoding"> the name of the HL7 encoding to use (eg "XML"; most implementations
        ///                         support only one encoding) </param>
        ///
        /// <returns>   A System.String. </returns>

        protected internal override System.String DoEncode(IMessage source, System.String encoding)
        {
            if (!encoding.Equals("XML"))
            {
                throw new EncodingNotSupportedException("XMLParser supports only XML encoding");
            }
            return this.Encode(source);
        }

        /// <summary>   Formats a Message object into an HL7 message string using this parser's default
        ///             encoding (XML encoding). This method calls the abstract method
        ///             <code>encodeDocument(...)</code> in order to obtain XML Document object
        ///             representation of the Message, then serializes it to a String. </summary>
        /// <summary>   (e.g. required fields are null) </summary>
        ///
        /// <exception cref="HL7Exception"> Thrown when a HL 7 error condition occurs. </exception>
        ///
        /// <param name="source">   a Message object from which to construct an encoded message string. </param>
        ///
        /// <returns>   A System.String. </returns>

        protected internal override System.String DoEncode(IMessage source)
        {
            if (source is GenericMessage)
            {
                throw new HL7Exception("Can't XML-encode a GenericMessage.  Message must have a recognized structure.");
            }

            System.Xml.XmlDocument doc = this.EncodeDocument(source);
            doc.DocumentElement.SetAttribute("xmlns", "urn:hl7-org:v2xml");

            System.IO.StringWriter out_Renamed = new System.IO.StringWriter();

            return doc.OuterXml;
        }

        /// <summary>
        /// <p>Parses a message string and returns the corresponding Message object.  This method checks
        /// that the given message string is XML encoded, creates an XML Document object (using Xerces)
        /// from the given String, and calls the abstract method <code>parse(Document
        /// XMLMessage)</code></p>
        /// </summary>
        ///
        /// <exception cref="HL7Exception"> Thrown when a HL 7 error condition occurs. </exception>
        ///
        /// <param name="message">  a String that contains an HL7 message. </param>
        /// <param name="version">  the name of the HL7 version to which the message belongs (eg "2.5") </param>
        ///
        /// <returns>   An IMessage. </returns>

        protected internal override IMessage DoParse(System.String message, System.String version)
        {
            IMessage m = null;

            //parse message string into a DOM document 
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(new System.IO.StringReader(message));
                //rlb: Don't think we need to lock this...
                //lock (this)
                //{

                //    //UPDATE_NOT: Replaced the following
                //    //parser.parse(new XmlSourceSupport(new System.IO.StringReader(message)));
                //    //doc = parser.getDocument();
                //}
                m = this.ParseDocument(doc, version);
            }
            catch (System.Xml.XmlException e)
            {
                throw new HL7Exception("XmlException parsing XML", HL7Exception.APPLICATION_INTERNAL_ERROR, e);
            }
            catch (System.IO.IOException e)
            {
                throw new HL7Exception("IOException parsing XML", HL7Exception.APPLICATION_INTERNAL_ERROR, e);
            }

            return m;
        }

        /// <summary>
        /// Checks if <code>Node</code> content should be kept as original (ie.: whitespaces won't be
        /// removed)
        /// </summary>
        ///
        /// <param name="node"> The target <code>Node</code> </param>
        ///
        /// <returns>
        /// boolean <code>true</code> if whitespaces should not be removed from node content,
        /// <code>false</code> otherwise.
        /// </returns>

        protected internal virtual bool KeepAsOriginal(System.Xml.XmlNode node)
        {
            if (node.Name == null)
            {
                return false;
            }
            return this.concatKeepAsOriginalNodes.IndexOf(node.Name) != -1;
        }

        /// <summary>
        /// Attempts to retrieve the value of a leaf tag without using DOM or SAX.  
        /// This method searches the given message string for the given tag name, and returns everything
        /// after the given tag and before the start of the next tag.  Whitespace is stripped.  This is
        /// intended only for lead nodes, as the value is considered to end at the start of the next tag,
        /// regardless of whether it is the matching end tag or some other nested tag.  
        /// </summary>
        ///
        /// <exception cref="HL7Exception"> Thrown when a HL 7 error condition occurs. </exception>
        ///
        /// <param name="message">  a string message in XML form. </param>
        /// <param name="tagName">  the name of the XML tag, e.g. "MSA.2". </param>
        /// <param name="startAt">  the character location at which to start searching. </param>
        ///
        /// <returns>   A System.String. </returns>

        protected internal virtual System.String ParseLeaf(System.String message, System.String tagName, int startAt)
        {
            System.String value_Renamed = null;

            int tagStart = message.IndexOf("<" + tagName, startAt);
            if (tagStart < 0)
            {
                tagStart = message.IndexOf("<" + tagName.ToUpper(), startAt);
            }
            int valStart = message.IndexOf(">", tagStart) + 1;
            int valEnd = message.IndexOf("<", valStart);

            if (tagStart >= 0 && valEnd >= valStart)
            {
                value_Renamed = message.Substring(valStart, (valEnd) - (valStart));
            }
            else
            {
                throw new HL7Exception(
                    "Couldn't find " + tagName + " in message beginning: "
                    + message.Substring(0, (System.Math.Min(150, message.Length)) - (0)),
                    HL7Exception.REQUIRED_FIELD_MISSING);
            }

            return value_Renamed;
        }

        /// <summary>
        /// Removes all unecessary whitespace from the given String (intended to be used with Primitive
        /// values).  
        /// This includes leading and trailing whitespace, and repeated space characters.  Carriage
        /// returns, line feeds, and tabs are replaced with spaces.
        /// </summary>
        ///
        /// <param name="s">    The ISegment to process. </param>
        ///
        /// <returns>   A System.String. </returns>

        protected internal virtual System.String RemoveWhitespace(System.String s)
        {
            s = s.Replace('\r', ' ');
            s = s.Replace('\n', ' ');
            s = s.Replace('\t', ' ');

            bool repeatedSpacesExist = true;
            while (repeatedSpacesExist)
            {
                int loc = s.IndexOf("  ");
                if (loc < 0)
                {
                    repeatedSpacesExist = false;
                }
                else
                {
                    System.Text.StringBuilder buf = new System.Text.StringBuilder();
                    buf.Append(s.Substring(0, (loc) - (0)));
                    buf.Append(" ");
                    buf.Append(s.Substring(loc + 2));
                    s = buf.ToString();
                }
            }
            return s.Trim();
        }

        /// <summary>
        /// Populates the given Element with data from the given Type, by inserting Elements
        /// corresponding to the Type's components and values.  Returns true if the given type contains a
        /// value (i.e. for Primitives, if getValue() doesn't return null, and for Composites, if at
        /// least one underlying Primitive doesn't return null).
        /// </summary>
        ///
        /// <param name="datatypeObject">   The datatype object. </param>
        /// <param name="datatypeElement">  Element describing the datatype. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        private bool Encode(IType datatypeObject, System.Xml.XmlElement datatypeElement)
        {
            bool hasData = false;
            if (datatypeObject is Varies)
            {
                hasData = this.EncodeVaries((Varies)datatypeObject, datatypeElement);
            }
            else if (datatypeObject is IPrimitive)
            {
                hasData = this.EncodePrimitive((IPrimitive)datatypeObject, datatypeElement);
            }
            else if (datatypeObject is IComposite)
            {
                hasData = this.EncodeComposite((IComposite)datatypeObject, datatypeElement);
            }
            return hasData;
        }

        /// <summary>
        /// Encodes a Composite in XML by looping through it's components, creating new children for each
        /// of them (with the appropriate names) and populating them by calling encode(Type, Element)
        /// using these children.  Returns true if at least one component contains a value.  
        /// </summary>
        ///
        /// <exception cref="DataTypeException">    Thrown when a Data Type error condition occurs. </exception>
        ///
        /// <param name="datatypeObject">   The datatype object. </param>
        /// <param name="datatypeElement">  Element describing the datatype. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        private bool EncodeComposite(IComposite datatypeObject, System.Xml.XmlElement datatypeElement)
        {
            IType[] components = datatypeObject.Components;
            bool hasValue = false;
            for (int i = 0; i < components.Length; i++)
            {
                System.String name = MakeElementName(datatypeObject, i + 1);
                System.Xml.XmlElement newNode = datatypeElement.OwnerDocument.CreateElement(name);
                bool componentHasValue = Encode(components[i], newNode);
                if (componentHasValue)
                {
                    try
                    {
                        datatypeElement.AppendChild(newNode);
                    }
                    catch (System.Exception e)
                    {
                        throw new DataTypeException("DOMException encoding Composite: ", e);
                    }
                    hasValue = true;
                }
            }
            return hasValue;
        }

        /// <summary>
        /// Encodes a Primitive in XML by adding it's value as a child of the given Element.  
        /// Returns true if the given Primitive contains a value.  
        /// </summary>
        ///
        /// <exception cref="DataTypeException">    Thrown when a Data Type error condition occurs. </exception>
        ///
        /// <param name="datatypeObject">   The datatype object. </param>
        /// <param name="datatypeElement">  Element describing the datatype. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        private bool EncodePrimitive(IPrimitive datatypeObject, System.Xml.XmlElement datatypeElement)
        {
            bool hasValue = false;
            if (datatypeObject.Value != null && !datatypeObject.Value.Equals(""))
            {
                hasValue = true;
            }

            System.Xml.XmlText t = datatypeElement.OwnerDocument.CreateTextNode(datatypeObject.Value);
            if (hasValue)
            {
                try
                {
                    datatypeElement.AppendChild(t);
                }
                catch (System.Exception e)
                {
                    throw new DataTypeException("DOMException encoding Primitive: ", e);
                }
            }
            return hasValue;
        }

        /// <summary>
        /// Encodes a Varies type by extracting it's data field and encoding that.  Returns true if the
        /// data field (or one of its components) contains a value.  
        /// </summary>
        ///
        /// <param name="datatypeObject">   The datatype object. </param>
        /// <param name="datatypeElement">  Element describing the datatype. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        private bool EncodeVaries(Varies datatypeObject, System.Xml.XmlElement datatypeElement)
        {
            bool hasData = false;
            if (datatypeObject.Data != null)
            {
                hasData = Encode(datatypeObject.Data, datatypeElement);
            }
            return hasData;
        }

        /// <summary>   Returns true if any of the given element's children are elements. </summary>
        ///
        /// <param name="e">    Element describing the e. </param>
        ///
        /// <returns>   true if child element, false if not. </returns>

        private bool HasChildElement(System.Xml.XmlElement e)
        {
            System.Xml.XmlNodeList children = e.ChildNodes;
            bool hasElement = false;
            int c = 0;
            while (c < children.Count && !hasElement)
            {
                if (System.Convert.ToInt16(children.Item(c).NodeType) == (short)System.Xml.XmlNodeType.Element)
                {
                    hasElement = true;
                }
                c++;
            }
            return hasElement;
        }

        /// <summary> Returns the expected XML element name for the given child of a message constituent 
        /// of the given class (the class should be a Composite or Segment class). 
        /// </summary>
        /*private String makeElementName(Class c, int child) {
        String longClassName = c.getName();
        String shortClassName = longClassName.substring(longClassName.lastIndexOf('.') + 1, longClassName.length());
        if (shortClassName.startsWith("Valid")) {
        shortClassName = shortClassName.substring(5, shortClassName.length());
        }
        return shortClassName + "." + child;
        }*/

        /// <summary>
        /// Returns the expected XML element name for the given child of the given Segment.
        /// </summary>
        ///
        /// <param name="s">        The ISegment to process. </param>
        /// <param name="child">    The child. </param>
        ///
        /// <returns>   A System.String. </returns>

        private System.String MakeElementName(ISegment s, int child)
        {
            return s.GetStructureName() + "." + child;
        }

        /// <summary>
        /// Returns the expected XML element name for the given child of the given Composite.
        /// </summary>
        ///
        /// <param name="composite">    The composite. </param>
        /// <param name="child">        The child. </param>
        ///
        /// <returns>   A System.String. </returns>

        private System.String MakeElementName(IComposite composite, int child)
        {
            return composite.TypeName + "." + child;
        }

        /// <summary>
        /// Populates a Composite type by looping through it's children, finding corresponding Elements
        /// among the children of the given Element, and calling parse(Type, Element) for each.
        /// </summary>
        ///
        /// <param name="datatypeObject">   The datatype object. </param>
        /// <param name="datatypeElement">  Element describing the datatype. </param>

        private void ParseComposite(IComposite datatypeObject, System.Xml.XmlElement datatypeElement)
        {
            if (datatypeObject is GenericComposite)
            {
                //elements won't be named GenericComposite.x
                System.Xml.XmlNodeList children = datatypeElement.ChildNodes;
                int compNum = 0;
                for (int i = 0; i < children.Count; i++)
                {
                    if (System.Convert.ToInt16(children.Item(i).NodeType) == (short)System.Xml.XmlNodeType.Element)
                    {
                        Parse(datatypeObject[compNum], (System.Xml.XmlElement)children.Item(i));
                        compNum++;
                    }
                }
            }
            else
            {
                IType[] children = datatypeObject.Components;
                for (int i = 0; i < children.Length; i++)
                {
                    System.Xml.XmlNodeList matchingElements =
                        datatypeElement.GetElementsByTagName(MakeElementName(datatypeObject, i + 1));
                    if (matchingElements.Count > 0)
                    {
                        Parse(children[i], (System.Xml.XmlElement)matchingElements.Item(0));
                            //components don't repeat - use 1st
                    }
                }
            }
        }

        /// <summary>   Parses a primitive type by filling it with text child, if any. </summary>
        ///
        /// <param name="datatypeObject">   The datatype object. </param>
        /// <param name="datatypeElement">  Element describing the datatype. </param>

        private void ParsePrimitive(IPrimitive datatypeObject, System.Xml.XmlElement datatypeElement)
        {
            System.Xml.XmlNodeList children = datatypeElement.ChildNodes;
            int c = 0;
            bool full = false;
            while (c < children.Count && !full)
            {
                System.Xml.XmlNode child = children.Item(c++);
                if (System.Convert.ToInt16(child.NodeType) == (short)System.Xml.XmlNodeType.Text)
                {
                    try
                    {
                        if (child.Value != null && !child.Value.Equals(""))
                        {
                            if (this.KeepAsOriginal(child.ParentNode))
                            {
                                datatypeObject.Value = child.Value;
                            }
                            else
                            {
                                datatypeObject.Value = this.RemoveWhitespace(child.Value);
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        log.Error("Error parsing primitive value from TEXT_NODE", e);
                    }
                    full = true;
                }
            }
        }

        /// <summary>   Parse reps. </summary>
        ///
        /// <param name="segmentObject">    The segment object. </param>
        /// <param name="segmentElement">   Element describing the segment. </param>
        /// <param name="fieldName">        Name of the field. </param>
        /// <param name="fieldNum">         The field number. </param>

        private void ParseReps(
            ISegment segmentObject,
            System.Xml.XmlElement segmentElement,
            System.String fieldName,
            int fieldNum)
        {
            System.Xml.XmlNodeList reps = segmentElement.GetElementsByTagName(fieldName);
            for (int i = 0; i < reps.Count; i++)
            {
                Parse(segmentObject.GetField(fieldNum, i), (System.Xml.XmlElement)reps.Item(i));
            }
        }

        /// <summary>
        /// Parses an XML element into a Varies by determining whether the element is primitive or
        /// composite, calling setData() on the Varies with a new generic primitive or composite as
        /// appropriate, and then calling parse again with the new Type object.  
        /// </summary>
        ///
        /// <param name="datatypeObject">   The datatype object. </param>
        /// <param name="datatypeElement">  Element describing the datatype. </param>

        private void ParseVaries(Varies datatypeObject, System.Xml.XmlElement datatypeElement)
        {
            //figure out what data type it holds 
            //short nodeType = datatypeElement.getFirstChild().getNodeType();        
            if (!this.HasChildElement(datatypeElement))
            {
                //it's a primitive 
                datatypeObject.Data = new GenericPrimitive(datatypeObject.Message);
            }
            else
            {
                //it's a composite ... almost know what type, except that we don't have the version here 
                datatypeObject.Data = new GenericComposite(datatypeObject.Message);
            }
            Parse(datatypeObject.Data, datatypeElement);
        }

        #endregion

        /// <summary>   The anonymous class XML parser. </summary>
        private class AnonymousClassXMLParser : XMLParser
        {
            #region Public Methods and Operators

            /// <summary>
            /// <p>Creates an XML Document that corresponds to the given Message object.</p><p>If you are
            /// implementing this method, you should create an XML Document, and insert XML Elements into it
            /// that correspond to the groups and segments that belong to the message type that your subclass
            /// of XMLParser supports.  Then, for each segment in the message, call the method
            /// <code>encode(Segment segmentObject, Element segmentElement)</code> using the Element for
            /// that segment and the corresponding Segment object from the given Message.</p>
            /// </summary>
            ///
            /// <param name="source">   Source for the. </param>
            ///
            /// <returns>   A System.Xml.XmlDocument. </returns>

            public override System.Xml.XmlDocument EncodeDocument(IMessage source)
            {
                return null;
            }

            /// <summary>
            /// Returns the version ID (MSH-12) from the given message, without fully parsing the message.
            /// The version is needed prior to parsing in order to determine the message class into which the
            /// text of the message should be parsed.
            /// </summary>
            ///
            /// <param name="message">  a String that contains an HL7 message. </param>
            ///
            /// <returns>   The version. </returns>

            public override System.String GetVersion(System.String message)
            {
                return null;
            }

            /// <summary>   <p>Creates and populates a Message object from an XML Document that contains an
            ///             XML-encoded HL7 message.</p><p>The easiest way to implement this method for a
            ///             particular message structure is as follows:
            ///             <ol><li>Create an instance of the Message type you are going to handle with your
            ///             subclass
            ///             of XMLParser</li><li>Go through the given Document and find the Elements that
            ///             represent the top level of each message segment.</li><li>For each of these
            ///             segments, call <code>parse(Segment segmentObject, Element segmentElement)</code>,
            ///             providing the appropriate Segment from your Message object, and the corresponding
            ///             Element.</li></ol>At the end of this process, your Message object should be
            ///             populated with data from the XML Document.</p> </summary>
            /// <summary>   is not supported by this parser. </summary>
            ///
            /// <param name="XMLMessage">   Message describing the XML. </param>
            /// <param name="version">      The version. </param>
            ///
            /// <returns>   An IMessage. </returns>

            public override IMessage ParseDocument(System.Xml.XmlDocument XMLMessage, System.String version)
            {
                return null;
            }

            #endregion
        }
    }
}