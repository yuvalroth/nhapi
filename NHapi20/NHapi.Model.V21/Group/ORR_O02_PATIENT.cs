using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V21.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V21.Group
{
/// <summary>
/// Represents the ORR_O02_PATIENT Group.  A Group is an ordered collection of message
///  segments that can repeat together or be optionally in/excluded together. This Group contains
///  the following elements:
/// <ol>
/// <li>0: PID (PATIENT IDENTIFICATION) optional </li>
/// <li>1: NTE (NOTES AND COMMENTS) optional repeating</li>
/// <li>2: ORR_O02_ORDER (a Group object) repeating</li>
/// </ol>
/// </summary>

[Serializable]
public class ORR_O02_PATIENT : AbstractGroup {

    /// <summary>   Creates a new ORR_O02_PATIENT Group. </summary>
    ///
    /// <param name="parent">   The parent. </param>
    /// <param name="factory">  The factory. </param>

	public ORR_O02_PATIENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(ORR_O02_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORR_O02_PATIENT - this is probably a bug in the source code generator.", e);
	   }
	}

    /// <summary>   Returns PID (PATIENT IDENTIFICATION) - creates it if necessary. </summary>
    ///
    /// <value> The PID. </value>

	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns  first repetition of NTE (NOTES AND COMMENTS) - creates it if necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The nte. </returns>

	public NTE GetNTE() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of NTE
    ///  * (NOTES AND COMMENTS) - creates it if necessary throws HL7Exception if the repetition
    ///  requested is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The nte. </returns>

	public NTE GetNTE(int rep) { 
	   return (NTE)this.GetStructure("NTE", rep);
	}

    /// <summary>   Gets the nte repetitions used. </summary>
    ///
    /// <value> The nte repetitions used. </value>

	public int NTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

    /// <summary>
    /// Returns  first repetition of ORR_O02_ORDER (a Group object) - creates it if necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The order. </returns>

	public ORR_O02_ORDER GetORDER() {
	   ORR_O02_ORDER ret = null;
	   try {
	      ret = (ORR_O02_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of ORR_O02_ORDER
    ///  * (a Group object) - creates it if necessary throws HL7Exception if the repetition requested
    ///  is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The order. </returns>

	public ORR_O02_ORDER GetORDER(int rep) { 
	   return (ORR_O02_ORDER)this.GetStructure("ORDER", rep);
	}

    /// <summary>   Gets the order repetitions used. </summary>
    ///
    /// <value> The order repetitions used. </value>

	public int ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER").Length; 
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
