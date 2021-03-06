using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V231.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
/// <summary>
/// Represents the CSU_C09_STUDY_PHARM Group.  A Group is an ordered collection of message
///  segments that can repeat together or be optionally in/excluded together. This Group contains
///  the following elements:
/// <ol>
/// <li>0: ORC (ORC - common order segment) optional </li>
/// <li>1: CSU_C09_RX_ADMIN (a Group object) repeating</li>
/// </ol>
/// </summary>

[Serializable]
public class CSU_C09_STUDY_PHARM : AbstractGroup {

    /// <summary>   Creates a new CSU_C09_STUDY_PHARM Group. </summary>
    ///
    /// <param name="parent">   The parent. </param>
    /// <param name="factory">  The factory. </param>

	public CSU_C09_STUDY_PHARM(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(CSU_C09_RX_ADMIN), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CSU_C09_STUDY_PHARM - this is probably a bug in the source code generator.", e);
	   }
	}

    /// <summary>   Returns ORC (ORC - common order segment) - creates it if necessary. </summary>
    ///
    /// <value> The orc. </value>

	public ORC ORC { 
get{
	   ORC ret = null;
	   try {
	      ret = (ORC)this.GetStructure("ORC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns  first repetition of CSU_C09_RX_ADMIN (a Group object) - creates it if necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The receive admin. </returns>

	public CSU_C09_RX_ADMIN GetRX_ADMIN() {
	   CSU_C09_RX_ADMIN ret = null;
	   try {
	      ret = (CSU_C09_RX_ADMIN)this.GetStructure("RX_ADMIN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of CSU_C09_RX_ADMIN
    ///  * (a Group object) - creates it if necessary throws HL7Exception if the repetition requested
    ///  is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The receive admin. </returns>

	public CSU_C09_RX_ADMIN GetRX_ADMIN(int rep) { 
	   return (CSU_C09_RX_ADMIN)this.GetStructure("RX_ADMIN", rep);
	}

    /// <summary>   Gets the receive admin repetitions used. </summary>
    ///
    /// <value> The receive admin repetitions used. </value>

	public int RX_ADMINRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RX_ADMIN").Length; 
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
