using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V231.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
/// <summary>
/// Represents the SUR_P09_FACILITY Group.  A Group is an ordered collection of message
///  segments that can repeat together or be optionally in/excluded together. This Group contains
///  the following elements:
/// <ol>
/// <li>0: FAC (FAC - facility segment) </li>
/// <li>1: SUR_P09_PRODUCT (a Group object) repeating</li>
/// <li>2: PSH (PSH - product summary header segment) </li>
/// <li>3: SUR_P09_FACILITY_DETAIL (a Group object) repeating</li>
/// </ol>
/// </summary>

[Serializable]
public class SUR_P09_FACILITY : AbstractGroup {

    /// <summary>   Creates a new SUR_P09_FACILITY Group. </summary>
    ///
    /// <param name="parent">   The parent. </param>
    /// <param name="factory">  The factory. </param>

	public SUR_P09_FACILITY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(FAC), true, false);
	      this.add(typeof(SUR_P09_PRODUCT), true, true);
	      this.add(typeof(PSH), true, false);
	      this.add(typeof(SUR_P09_FACILITY_DETAIL), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SUR_P09_FACILITY - this is probably a bug in the source code generator.", e);
	   }
	}

    /// <summary>   Returns FAC (FAC - facility segment) - creates it if necessary. </summary>
    ///
    /// <value> The fac. </value>

	public FAC FAC { 
get{
	   FAC ret = null;
	   try {
	      ret = (FAC)this.GetStructure("FAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns  first repetition of SUR_P09_PRODUCT (a Group object) - creates it if necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The product. </returns>

	public SUR_P09_PRODUCT GetPRODUCT() {
	   SUR_P09_PRODUCT ret = null;
	   try {
	      ret = (SUR_P09_PRODUCT)this.GetStructure("PRODUCT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of SUR_P09_PRODUCT
    ///  * (a Group object) - creates it if necessary throws HL7Exception if the repetition requested
    ///  is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The product. </returns>

	public SUR_P09_PRODUCT GetPRODUCT(int rep) { 
	   return (SUR_P09_PRODUCT)this.GetStructure("PRODUCT", rep);
	}

    /// <summary>   Gets the product repetitions used. </summary>
    ///
    /// <value> The product repetitions used. </value>

	public int PRODUCTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRODUCT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

    /// <summary>
    /// Returns PSH (PSH - product summary header segment) - creates it if necessary.
    /// </summary>
    ///
    /// <value> The psh. </value>

	public PSH PSH { 
get{
	   PSH ret = null;
	   try {
	      ret = (PSH)this.GetStructure("PSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns  first repetition of SUR_P09_FACILITY_DETAIL (a Group object) - creates it if
    /// necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The facility detail. </returns>

	public SUR_P09_FACILITY_DETAIL GetFACILITY_DETAIL() {
	   SUR_P09_FACILITY_DETAIL ret = null;
	   try {
	      ret = (SUR_P09_FACILITY_DETAIL)this.GetStructure("FACILITY_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of SUR_P09_FACILITY_DETAIL
    ///  * (a Group object) - creates it if necessary throws HL7Exception if the repetition requested
    ///  is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The facility detail. </returns>

	public SUR_P09_FACILITY_DETAIL GetFACILITY_DETAIL(int rep) { 
	   return (SUR_P09_FACILITY_DETAIL)this.GetStructure("FACILITY_DETAIL", rep);
	}

    /// <summary>   Gets the facility detail repetitions used. </summary>
    ///
    /// <value> The facility detail repetitions used. </value>

	public int FACILITY_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FACILITY_DETAIL").Length; 
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
