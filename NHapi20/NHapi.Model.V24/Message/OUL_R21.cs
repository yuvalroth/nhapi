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
/// Represents a OUL_R21 message structure (see chapter 7). This structure contains the following
/// elements:
/// <ol>
/// <li>0: MSH (Message Header) </li>
/// <li>1: NTE (Notes and Comments) optional </li>
/// <li>2: OUL_R21_PATIENT (a Group object) optional </li>
/// <li>3: OUL_R21_VISIT (a Group object) optional </li>
/// <li>4: OUL_R21_ORDER_OBSERVATION (a Group object) repeating</li>
/// <li>5: DSC (Continuation Pointer) optional </li>
/// </ol>
/// </summary>

[Serializable]
public class OUL_R21 : AbstractMessage  {

    /// <summary>   Creates a new OUL_R21 Group with custom IModelClassFactory. </summary>
    ///
    /// <param name="factory">  The factory. </param>

	public OUL_R21(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

    /// <summary>   Creates a new OUL_R21 Group with DefaultModelClassFactory. </summary>
	public OUL_R21() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

    /// <summary>
    /// initalize method for OUL_R21.  This does the segment setup for the message.
    /// </summary>
    ///
    /// <param name="factory">  The factory. </param>

	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(NTE), false, false);
	      this.add(typeof(OUL_R21_PATIENT), false, false);
	      this.add(typeof(OUL_R21_VISIT), false, false);
	      this.add(typeof(OUL_R21_ORDER_OBSERVATION), true, true);
	      this.add(typeof(DSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OUL_R21 - this is probably a bug in the source code generator.", e);
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

    /// <summary>   Returns NTE (Notes and Comments) - creates it if necessary. </summary>
    ///
    /// <value> The nte. </value>

	public NTE NTE { 
get{
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>   Returns OUL_R21_PATIENT (a Group object) - creates it if necessary. </summary>
    ///
    /// <value> The patient. </value>

	public OUL_R21_PATIENT PATIENT { 
get{
	   OUL_R21_PATIENT ret = null;
	   try {
	      ret = (OUL_R21_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>   Returns OUL_R21_VISIT (a Group object) - creates it if necessary. </summary>
    ///
    /// <value> The visit. </value>

	public OUL_R21_VISIT VISIT { 
get{
	   OUL_R21_VISIT ret = null;
	   try {
	      ret = (OUL_R21_VISIT)this.GetStructure("VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns  first repetition of OUL_R21_ORDER_OBSERVATION (a Group object) - creates it if
    /// necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The order observation. </returns>

	public OUL_R21_ORDER_OBSERVATION GetORDER_OBSERVATION() {
	   OUL_R21_ORDER_OBSERVATION ret = null;
	   try {
	      ret = (OUL_R21_ORDER_OBSERVATION)this.GetStructure("ORDER_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of OUL_R21_ORDER_OBSERVATION
    ///  * (a Group object) - creates it if necessary throws HL7Exception if the repetition requested
    ///  is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The order observation. </returns>

	public OUL_R21_ORDER_OBSERVATION GetORDER_OBSERVATION(int rep) { 
	   return (OUL_R21_ORDER_OBSERVATION)this.GetStructure("ORDER_OBSERVATION", rep);
	}

    /// <summary>   Gets the order observation repetitions used. </summary>
    ///
    /// <value> The order observation repetitions used. </value>

	public int ORDER_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

    /// <summary>   Returns DSC (Continuation Pointer) - creates it if necessary. </summary>
    ///
    /// <value> The dsc. </value>

	public DSC DSC { 
get{
	   DSC ret = null;
	   try {
	      ret = (DSC)this.GetStructure("DSC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
