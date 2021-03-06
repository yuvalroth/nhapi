using System;
using NHapi.Base.Log;
using NHapi.Model.V24.Group;
using NHapi.Model.V24.Segment;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V24.Message

{
/// <summary>
/// Represents a NMD_N02 message structure (see chapter 14). This structure contains the
/// following elements:
/// <ol>
/// <li>0: MSH (Message Header) </li>
/// <li>1: NMD_N02_CLOCK_AND_STATS_WITH_NOTES (a Group object) repeating</li>
/// </ol>
/// </summary>

[Serializable]
public class NMD_N02 : AbstractMessage  {

    /// <summary>   Creates a new NMD_N02 Group with custom IModelClassFactory. </summary>
    ///
    /// <param name="factory">  The factory. </param>

	public NMD_N02(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

    /// <summary>   Creates a new NMD_N02 Group with DefaultModelClassFactory. </summary>
	public NMD_N02() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

    /// <summary>
    /// initalize method for NMD_N02.  This does the segment setup for the message.
    /// </summary>
    ///
    /// <param name="factory">  The factory. </param>

	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(NMD_N02_CLOCK_AND_STATS_WITH_NOTES), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMD_N02 - this is probably a bug in the source code generator.", e);
	   }
	}

    /// <summary>
    /// Returns the version number.  This default implementation inspects this.GetClass().getName().
    /// This should be overridden if you are putting a custom message definition in your own package,
    /// or it will default.
    /// </summary>
    ///
    /// <value> s 2.4 if not obvious from package name. </value>

	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}

    /// <summary>   Returns MSH (Message Header) - creates it if necessary. </summary>
    ///
    /// <value> The msh. </value>

	public MSH MSH { 
get{
	   MSH ret = null;
	   try {
	      ret = (MSH)this.GetStructure("MSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns  first repetition of NMD_N02_CLOCK_AND_STATS_WITH_NOTES (a Group object) - creates it
    /// if necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The clock and stats with notes. </returns>

	public NMD_N02_CLOCK_AND_STATS_WITH_NOTES GetCLOCK_AND_STATS_WITH_NOTES() {
	   NMD_N02_CLOCK_AND_STATS_WITH_NOTES ret = null;
	   try {
	      ret = (NMD_N02_CLOCK_AND_STATS_WITH_NOTES)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of NMD_N02_CLOCK_AND_STATS_WITH_NOTES
    ///  * (a Group object) - creates it if necessary throws HL7Exception if the repetition requested
    ///  is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The clock and stats with notes. </returns>

	public NMD_N02_CLOCK_AND_STATS_WITH_NOTES GetCLOCK_AND_STATS_WITH_NOTES(int rep) { 
	   return (NMD_N02_CLOCK_AND_STATS_WITH_NOTES)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES", rep);
	}

    /// <summary>   Gets the clock and stats with notes repetitions used. </summary>
    ///
    /// <value> The clock and stats with notes repetitions used. </value>

	public int CLOCK_AND_STATS_WITH_NOTESRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLOCK_AND_STATS_WITH_NOTES").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

}
}
