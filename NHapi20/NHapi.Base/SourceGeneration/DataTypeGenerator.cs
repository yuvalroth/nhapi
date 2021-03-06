/// <summary>The contents of this file are subject to the Mozilla Public License Version 1.1 
/// (the "License"); you may not use this file except in compliance with the License. 
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/ 
/// Software distributed under the License is distributed on an "AS IS" basis, 
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the 
/// specific language governing rights and limitations under the License. 
/// The Original Code is "DataTypeGenerator.java".  Description: 
/// "Generates skeletal source code for Datatype classes based on the 
/// HL7 database" 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C) 
/// 2001.  All Rights Reserved. 
/// Contributor(s):  Eric Poiseau. 
/// Alternatively, the contents of this file may be used under the terms of the 
/// GNU General Public License (the  �GPL�), in which case the provisions of the GPL are 
/// applicable instead of those above.  If you wish to allow use of your version of this 
/// file only under the terms of the GPL and not to allow others to use your version 
/// of this file under the MPL, indicate your decision by deleting  the provisions above 
/// and replace  them with the notice and other provisions required by the GPL License.  
/// If you do not delete the provisions above, a recipient may use your version of 
/// this file under either the MPL or the GPL. 
/// </summary>

namespace NHapi.Base.SourceGeneration
{
    using System;

    using NHapi.Base.Log;

    /// <summary>
    /// Generates skeletal source code for Datatype classes based on the HL7 database.  
    /// </summary>

    public class DataTypeGenerator : System.Object
    {
        #region Static Fields

        /// <summary>   The log. </summary>
        private static readonly IHapiLog log;

        #endregion

        #region Constructors and Destructors

        /// <summary>   Initializes static members of the DataTypeGenerator class. </summary>
        static DataTypeGenerator()
        {
            log = HapiLogFactory.GetHapiLog(typeof(DataTypeGenerator));
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>   Main entry-point for this application. </summary>
        ///
        /// <param name="args"> Array of command-line argument strings. </param>

        [STAThread]
        public static void Main(System.String[] args)
        {
            //System.out.println(makePrimitive("ID", "identifier"));
            try
            {
                System.Type.GetType("sun.jdbc.odbc.JdbcOdbcDriver");
                //System.setProperty("ca.on.uhn.hl7.database.url", "jdbc:odbc:hl7v25");        
                //make(new File("c:/testsourcegen"), args[0], args[1]);
                //make(new File("c:/testsourcegen"), "CE_0048", "2.3");
                makeAll("c:/testsourcegen", "2.5");
            }
            catch (System.Exception e)
            {
                SupportClass.WriteStackTrace(e, Console.Error);
            }
        }

        /// <summary>   Creates source code for a single data type in the HL7 normative database. </summary>
        ///
        /// <exception cref="IOException">  Thrown when an IO failure occurred. </exception>
        ///
        /// <param name="targetDirectory">  the directory into which the file will be written. </param>
        /// <param name="dataType">         Type of the data. </param>
        /// <param name="version">          the HL7 version of the intended data type. </param>
        ///
        /// ### <param name="datatype"> the name (e.g. ST, ID, etc.) of the data type to be created. </param>

        public static void make(System.IO.FileInfo targetDirectory, System.String dataType, System.String version)
        {
            Console.WriteLine(" Writing " + targetDirectory.FullName + dataType);
            //make sure that targetDirectory is a directory ... 
            if (!System.IO.Directory.Exists(targetDirectory.FullName))
            {
                throw new System.IO.IOException("Can't create file in " + targetDirectory + " - it is not a directory.");
            }

            //get any components for this data type
            System.Data.OleDb.OleDbConnection conn = NormativeDatabase.Instance.Connection;
            System.Data.OleDb.OleDbCommand stmt = SupportClass.TransactionManager.manager.CreateStatement(conn);
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            //this query is adapted from the XML SIG informative document
            sql.Append(
                "SELECT HL7DataStructures.data_structure, HL7DataStructureComponents.seq_no, HL7DataStructures.description, HL7DataStructureComponents.table_id,  ");
            sql.Append(
                "HL7Components.description, HL7Components.table_id, HL7Components.data_type_code, HL7Components.data_structure ");
            sql.Append(
                "FROM HL7Versions LEFT JOIN (HL7DataStructures LEFT JOIN (HL7DataStructureComponents LEFT JOIN HL7Components ");
            sql.Append("ON HL7DataStructureComponents.comp_no = HL7Components.comp_no AND ");
            sql.Append("HL7DataStructureComponents.version_id = HL7Components.version_id) ");
            sql.Append("ON HL7DataStructures.version_id = HL7DataStructureComponents.version_id ");
            sql.Append("AND HL7DataStructures.data_structure = HL7DataStructureComponents.data_structure) ");
            sql.Append("ON HL7DataStructures.version_id = HL7Versions.version_id ");
            sql.Append("WHERE HL7DataStructures.data_structure = '");
            sql.Append(dataType);
            sql.Append("' AND HL7Versions.hl7_version = '");
            sql.Append(version);
            sql.Append("' ORDER BY HL7DataStructureComponents.seq_no");
            System.Data.OleDb.OleDbCommand temp_OleDbCommand;
            temp_OleDbCommand = stmt;
            temp_OleDbCommand.CommandText = sql.ToString();
            System.Data.OleDb.OleDbDataReader rs = temp_OleDbCommand.ExecuteReader();

            System.Collections.ArrayList dataTypes = new System.Collections.ArrayList(20);
            System.Collections.ArrayList descriptions = new System.Collections.ArrayList(20);
            System.Collections.ArrayList tables = new System.Collections.ArrayList(20);
            System.String description = null;
            while (rs.Read())
            {
                if (description == null)
                {
                    description = System.Convert.ToString(rs[3 - 1]);
                }

                System.String de = System.Convert.ToString(rs[5 - 1]);
                System.String dt = System.Convert.ToString(rs[8 - 1]);
                int ta = -1;
                if (!rs.IsDBNull(4 - 1))
                {
                    ta = rs.GetInt32(4 - 1);
                }
                //trim all CE_x to CE
                if (dt != null)
                {
                    if (dt.StartsWith("CE"))
                    {
                        dt = "CE";
                    }
                }
                //System.out.println("Component: " + de + "  Data Type: " + dt);  //for debugging
                dataTypes.Add(dt);
                descriptions.Add(de);
                tables.Add(ta);
            }
            if (dataType.ToUpper().Equals("TS"))
            {
                dataTypes[0] = "TSComponentOne";
            }

            rs.Close();
            stmt.Dispose();
            NormativeDatabase.Instance.returnConnection(conn);

            //if there is only one component make a Primitive, otherwise make a Composite
            System.String source = null;
            if (dataTypes.Count == 1)
            {
                if (dataType.Equals("FT") || dataType.Equals("ST") || dataType.Equals("TX") || dataType.Equals("NM")
                    || dataType.Equals("SI") || dataType.Equals("TN") || dataType.Equals("GTS"))
                {
                    source = makePrimitive(dataType, description, version);
                }
                else
                {
                    source = null; //note: IS, ID, DT, DTM, and TM are coded manually
                }
            }
            else if (dataTypes.Count > 1)
            {
                int numComponents = dataTypes.Count;
                //copy data into arrays ... 
                System.String[] type = new System.String[numComponents];
                System.String[] desc = new System.String[numComponents];
                int[] table = new int[numComponents];
                for (int i = 0; i < numComponents; i++)
                {
                    type[i] = ((System.String)dataTypes[i]);
                    desc[i] = ((System.String)descriptions[i]);
                    table[i] = ((System.Int32)tables[i]);
                }
                source = makeComposite(dataType, description, type, desc, table, version);
            }
            else
            {
                //no components?  
                //throw new DataTypeException("The data type " + dataType + " could not be found");
                Console.WriteLine("No components for " + dataType);
            }
            //System.out.println(source);

            //write to file ... 
            if (source != null)
            {
                System.String targetFile = targetDirectory + "/" + dataType + ".cs";
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(targetFile))
                {
                    writer.Write(source);
                    writer.Write("}"); //End namespace
                }
            }
            else
            {
                Console.WriteLine("No Source for " + dataType);
            }
        }

        /// <summary>
        /// Creates skeletal source code (without correct data structure but no business logic) for all
        /// data types found in the normative database.  For versions > 2.2, Primitive data types are not
        /// generated, because they are coded manually (as of HAPI 0.3).  
        /// </summary>
        ///
        /// <param name="baseDirectory">    Pathname of the base directory. </param>
        /// <param name="version">          the HL7 version of the intended data type. </param>

        public static void makeAll(System.String baseDirectory, System.String version)
        {
            //make base directory
            if (!(baseDirectory.EndsWith("\\") || baseDirectory.EndsWith("/")))
            {
                baseDirectory = baseDirectory + "/";
            }
            System.IO.FileInfo targetDir =
                SourceGenerator.makeDirectory(
                    baseDirectory + PackageManager.GetVersionPackagePath(version) + "Datatype");
            SourceGenerator.makeDirectory(baseDirectory + PackageManager.GetVersionPackagePath(version) + "Datatype");
            //get list of data types
            System.Collections.ArrayList types = new System.Collections.ArrayList();
            System.Data.OleDb.OleDbConnection conn = NormativeDatabase.Instance.Connection;
            System.Data.OleDb.OleDbCommand stmt = SupportClass.TransactionManager.manager.CreateStatement(conn);
            //get normal data types ... 
            System.Data.OleDb.OleDbCommand temp_OleDbCommand;
            temp_OleDbCommand = stmt;
            temp_OleDbCommand.CommandText =
                "select data_type_code from HL7DataTypes, HL7Versions where HL7Versions.version_id = HL7DataTypes.version_id and HL7Versions.hl7_version = '"
                + version + "'";
            System.Data.OleDb.OleDbDataReader rs = temp_OleDbCommand.ExecuteReader();
            while (rs.Read())
            {
                types.Add(System.Convert.ToString(rs[1 - 1]));
            }
            rs.Close();
            //get CF, CK, CM, CN, CQ sub-types ... 

            System.Data.OleDb.OleDbCommand temp_OleDbCommand2;
            temp_OleDbCommand2 = stmt;
            temp_OleDbCommand2.CommandText = "select data_structure from HL7DataStructures, HL7Versions where ("
                                             + "data_type_code  = 'CF' or " + "data_type_code  = 'CK' or "
                                             + "data_type_code  = 'CM' or " + "data_type_code  = 'CN' or "
                                             + "data_type_code  = 'CQ') and "
                                             + "HL7Versions.version_id = HL7DataStructures.version_id and  HL7Versions.hl7_version = '"
                                             + version + "'";
            rs = temp_OleDbCommand2.ExecuteReader();
            while (rs.Read())
            {
                types.Add(System.Convert.ToString(rs[1 - 1]));
            }

            stmt.Dispose();
            NormativeDatabase.Instance.returnConnection(conn);

            System.Console.Out.WriteLine("Generating " + types.Count + " datatypes for version " + version);
            if (types.Count == 0)
            {
                log.Warn("No version " + version + " data types found in database " + conn.Database);
            }

            for (int i = 0; i < types.Count; i++)
            {
                if (!((String)types[i]).Equals("*"))
                {
                    make(targetDir, (System.String)types[i], version);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>   Gets a description. </summary>
        ///
        /// <param name="description">  The description. </param>
        ///
        /// <returns>   The description. </returns>

        private static string GetDescription(string description)
        {
            string ret = description;
            ret = ret.Replace("&", "and");
            return ret;
        }

        /// <summary>
        /// Returns a String containing source code for a Composite data type. The dataTypes array
        /// contains the data type names (e.g. ST) of each component. The descriptions array contains the
        /// corresponding descriptions (e.g. string).
        /// </summary>
        ///
        /// <exception cref="DataTypeException">    Thrown when a Data Type error condition occurs. </exception>
        /// <exception cref="Exception">            Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="dataType">     Type of the data. </param>
        /// <param name="description">  The description. </param>
        /// <param name="dataTypes">    List of types of the data. </param>
        /// <param name="descriptions"> The descriptions. </param>
        /// <param name="tables">       The tables. </param>
        /// <param name="version">      the HL7 version of the intended data type. </param>
        ///
        /// <returns>   A System.String. </returns>

        private static System.String makeComposite(
            System.String dataType,
            System.String description,
            System.String[] dataTypes,
            System.String[] descriptions,
            int[] tables,
            System.String version)
        {
            System.Text.StringBuilder source = new System.Text.StringBuilder();
            source.Append("using System;\n");
            source.Append("using NHapi.Base.Model;\n");
            source.Append("using NHapi.Base.Log;\n");
            source.Append("using NHapi.Base;\n");
            source.Append("using NHapi.Base.Model.Primitive;\r\n\r\n");
            source.Append("namespace ");
            source.Append(PackageManager.GetVersionPackageName(version));
            source.Append("Datatype\r\n");
            source.Append("{\r\n\r\n");
            source.Append("///<summary>\r\n");
            source.Append("/// <p>The HL7 ");
            source.Append(dataType);
            source.Append(" (");
            source.Append(description);
            source.Append(") data type.  Consists of the following components: </p><ol>\r\n");
            for (int i = 0; i < dataTypes.Length; i++)
            {
                source.Append("/// <li>");
                source.Append(GetDescription(descriptions[i]));
                source.Append(" (");
                source.Append(dataTypes[i]);
                source.Append(")</li>\r\n");
            }
            source.Append("/// </ol>\r\n");
            source.Append("///</summary>\r\n");
            source.Append("[Serializable]\r\n");
            source.Append("public class ");
            source.Append(dataType);
            source.Append(" : AbstractType, IComposite");
            source.Append("{\r\n");
            source.Append("\tprivate IType[] data;\r\n\r\n");
            source.Append("\t///<summary>\r\n");
            source.Append("\t/// Creates a ");
            source.Append(dataType);
            source.Append(".\r\n");
            source.Append("\t/// <param name=\"message\">The Message to which this Type belongs</param>\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic ");
            source.Append(dataType);
            source.Append("(IMessage message) : this(message, null){}\r\n\r\n");
            source.Append("\t///<summary>\r\n");
            source.Append("\t/// Creates a ");
            source.Append(dataType);
            source.Append(".\r\n");
            source.Append("\t/// <param name=\"message\">The Message to which this Type belongs</param>\r\n");
            source.Append("\t/// <param name=\"description\">The description of this type</param>\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic ");
            source.Append(dataType);
            source.Append("(IMessage message, string description) : base(message, description){\r\n");
            source.Append("\t\tdata = new IType[");
            source.Append(dataTypes.Length);
            source.Append("];\r\n");
            for (int i = 0; i < dataTypes.Length; i++)
            {
                source.Append("\t\tdata[");
                source.Append(i);
                source.Append("] = new ");
                source.Append(SourceGenerator.getAlternateType(dataTypes[i], version));
                if (dataTypes[i].Equals("ID") || dataTypes[i].Equals("IS"))
                {
                    source.Append("(message, ");
                    source.Append(tables[i]);
                }
                else
                {
                    source.Append("(message");
                }
                if (descriptions[i] != null && descriptions[i].Trim().Length > 0)
                {
                    string desc = descriptions[i];
                    desc = desc.Replace("\"", "'");
                    desc = desc.Substring(0, 1).ToUpper() + desc.Substring(1);
                    source.Append(",\"" + desc + "\"");
                }
                source.Append(")");
                source.Append(";\r\n");
            }
            source.Append("\t}\r\n\r\n");
            source.Append("\t///<summary>\r\n");
            source.Append("\t/// Returns an array containing the data elements.\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic IType[] Components\r\n");
            source.Append("\t{ \r\n");
            source.Append("\t\tget{\r\n");
            source.Append("\t\t\treturn this.data; \r\n");
            source.Append("\t\t}\r\n");
            source.Append("\t}\r\n\r\n");
            source.Append("\t///<summary>\r\n");
            source.Append("\t/// Returns an individual data component.\r\n");
            source.Append("\t/// @throws DataTypeException if the given element number is out of range.\r\n");
            source.Append("\t///<param name=\"index\">The index item to get (zero based)</param>\r\n");
            source.Append(
                "\t///<returns>The data component (as a type) at the requested number (ordinal)</returns>\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic IType this[int index] { \r\n\r\n");
            source.Append("get{\r\n");
            source.Append("\t\ttry { \r\n");
            source.Append("\t\t\treturn this.data[index]; \r\n");
            source.Append("\t\t} catch (System.ArgumentOutOfRangeException) { \r\n");
            source.Append("\t\t\tthrow new DataTypeException(\"Element \" + index + \" doesn't exist in ");
            source.Append(dataTypes.Length);
            source.Append(" element ");
            source.Append(dataType);
            source.Append(" composite\"); \r\n");
            source.Append("\t\t} \r\n");
            source.Append("\t} \r\n");
            source.Append("\t} \r\n");
            //make type-specific accessors ... 
            for (int i = 0; i < dataTypes.Length; i++)
            {
                System.String dtName = SourceGenerator.getAlternateType(dataTypes[i], version);
                source.Append("\t///<summary>\r\n");
                source.Append("\t/// Returns ");
                source.Append(GetDescription(descriptions[i]));
                source.Append(" (component #");
                source.Append(i);
                source.Append(").  This is a convenience method that saves you from \r\n");
                source.Append("\t/// casting and handling an exception.\r\n");
                source.Append("\t///</summary>\r\n");
                source.Append("\tpublic ");
                source.Append(dtName);
                source.Append(" ");
                source.Append(SourceGenerator.MakeAccessorName(descriptions[i]));
                source.Append(" {\r\n");
                source.Append("get{\r\n");
                source.Append("\t   ");
                source.Append(dtName);
                source.Append(" ret = null;\r\n");
                source.Append("\t   try {\r\n");
                source.Append("\t      ret = (");
                source.Append(dtName);
                source.Append(")this[");
                source.Append(i);
                source.Append("];\r\n");
                source.Append("\t   } catch (DataTypeException e) {\r\n");
                source.Append(
                    "\t      HapiLogFactory.GetHapiLog(this.GetType()).Error(\"Unexpected problem accessing known data type component - this is a bug.\", e);\r\n");
                source.Append("\t      throw new System.Exception(\"An unexpected error ocurred\",e);\r\n");
                source.Append("\t   }\r\n");
                source.Append("\t   return ret;\r\n");
                source.Append("}\r\n\r\n");
                source.Append("}\r\n");
            }
            /*if (correspondingControlInterface != null) {
            source.append(Control.getImplementation(correspondingControlInterface, version));
            } */
            source.Append("}");

            return source.ToString();
        }

        /// <summary>
        /// Returns a String containing the complete source code for a Primitive HL7 data type.  Note:
        /// this method is no longer used, as all Primitives are now coded manually.  
        /// </summary>
        ///
        /// <param name="datatype">     The datatype. </param>
        /// <param name="description">  The description. </param>
        /// <param name="version">      the HL7 version of the intended data type. </param>
        ///
        /// <returns>   A System.String. </returns>

        private static System.String makePrimitive(
            System.String datatype,
            System.String description,
            System.String version)
        {
            System.Text.StringBuilder source = new System.Text.StringBuilder();

            source.Append("using System;\n");
            source.Append("using NHapi.Base.Model;\n");
            source.Append("using NHapi.Base;\n");
            source.Append("using NHapi.Base.Model.Primitive;\r\n");
            source.Append("namespace ");
            source.Append(PackageManager.GetVersionPackageName(version));
            source.Append("Datatype\r\n");
            source.Append("{\r\n");
            source.Append("///<summary>\r\n");
            source.Append("///Represents the HL7 ");
            source.Append(datatype);
            source.Append(" (");
            source.Append(description);
            source.Append(") datatype.  A ");
            source.Append(datatype);
            source.Append(" contains a single String value.\r\n");
            source.Append("///</summary>\r\n");
            source.Append("[Serializable]\r\n");
            source.Append("public class ");
            source.Append(datatype);
            source.Append(" : AbstractPrimitive ");
            source.Append(" {\r\n\r\n");
            //source.append("\tprotected String value;\r\n\r\n");
            source.Append("\t///<summary>\r\n");
            source.Append("\t///Constructs an uninitialized ");
            source.Append(datatype);
            source.Append(".\r\n");
            source.Append("\t///<param name=\"message\">The Message to which this Type belongs</param>\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic ");
            source.Append(datatype);
            source.Append("(IMessage message) : base(message){\r\n");
            source.Append("\t}\r\n\r\n");

            source.Append("\t///<summary>\r\n");
            source.Append("\t///Constructs an uninitialized ");
            source.Append(datatype);
            source.Append(".\r\n");
            source.Append("\t///<param name=\"message\">The Message to which this Type belongs</param>\r\n");
            source.Append("\t///<param name=\"description\">The description of this type</param>\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic ");
            source.Append(datatype);
            source.Append("(IMessage message, string description) : base(message,description){\r\n");
            source.Append("\t}\r\n\r\n");
            source.Append("\t///<summary>\r\n");
            source.Append("\t///  @return \"");
            source.Append(version);
            source.Append("\"\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic string getVersion() {\r\n");
            source.Append("\t    return \"");
            if (version.IndexOf("UCH") > -1)
            {
                source.Append("2.3");
            }
            else
            {
                source.Append(version);
            }
            source.Append("\";\r\n");
            source.Append("}\r\n");
            source.Append("}\r\n");

            return source.ToString();
        }

        #endregion

        //test
    }
}