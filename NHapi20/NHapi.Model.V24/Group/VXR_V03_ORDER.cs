using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V24.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V24.Group
{
/// <summary>
/// Represents the VXR_V03_ORDER Group.  A Group is an ordered collection of message
///  segments that can repeat together or be optionally in/excluded together. This Group contains
///  the following elements:
/// <ol>
/// <li>0: ORC (Common Order) optional </li>
/// <li>1: RXA (Pharmacy/Treatment Administration) </li>
/// <li>2: RXR (Pharmacy/Treatment Route) optional </li>
/// <li>3: VXR_V03_OBSERVATION (a Group object) optional repeating</li>
/// </ol>
/// </summary>

[Serializable]
public class VXR_V03_ORDER : AbstractGroup {

    /// <summary>   Creates a new VXR_V03_ORDER Group. </summary>
    ///
    /// <param name="parent">   The parent. </param>
    /// <param name="factory">  The factory. </param>

	public VXR_V03_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(RXA), true, false);
	      this.add(typeof(RXR), false, false);
	      this.add(typeof(VXR_V03_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating VXR_V03_ORDER - this is probably a bug in the source code generator.", e);
	   }
	}

    /// <summary>   Returns ORC (Common Order) - creates it if necessary. </summary>
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

    /// <summary>   Returns RXA (Pharmacy/Treatment Administration) - creates it if necessary. </summary>
    ///
    /// <value> The rxa. </value>

	public RXA RXA { 
get{
	   RXA ret = null;
	   try {
	      ret = (RXA)this.GetStructure("RXA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>   Returns RXR (Pharmacy/Treatment Route) - creates it if necessary. </summary>
    ///
    /// <value> The rxr. </value>

	public RXR RXR { 
get{
	   RXR ret = null;
	   try {
	      ret = (RXR)this.GetStructure("RXR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns  first repetition of VXR_V03_OBSERVATION (a Group object) - creates it if necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The observation. </returns>

	public VXR_V03_OBSERVATION GetOBSERVATION() {
	   VXR_V03_OBSERVATION ret = null;
	   try {
	      ret = (VXR_V03_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of VXR_V03_OBSERVATION
    ///  * (a Group object) - creates it if necessary throws HL7Exception if the repetition requested
    ///  is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The observation. </returns>

	public VXR_V03_OBSERVATION GetOBSERVATION(int rep) { 
	   return (VXR_V03_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

    /// <summary>   Gets the observation repetitions used. </summary>
    ///
    /// <value> The observation repetitions used. </value>

	public int OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION").Length; 
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
