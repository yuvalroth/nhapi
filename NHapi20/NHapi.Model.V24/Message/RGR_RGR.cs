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
/// Represents a RGR_RGR message structure (see chapter 4). This structure contains the following
/// elements:
/// <ol>
/// <li>0: MSH (Message Header) </li>
/// <li>1: MSA (Message Acknowledgment) </li>
/// <li>2: ERR (Error) optional </li>
/// <li>3: RGR_RGR_DEFINTION (a Group object) repeating</li>
/// <li>4: DSC (Continuation Pointer) optional </li>
/// </ol>
/// </summary>

[Serializable]
public class RGR_RGR : AbstractMessage  {

    /// <summary>   Creates a new RGR_RGR Group with custom IModelClassFactory. </summary>
    ///
    /// <param name="factory">  The factory. </param>

	public RGR_RGR(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

    /// <summary>   Creates a new RGR_RGR Group with DefaultModelClassFactory. </summary>
	public RGR_RGR() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

    /// <summary>
    /// initalize method for RGR_RGR.  This does the segment setup for the message.
    /// </summary>
    ///
    /// <param name="factory">  The factory. </param>

	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ERR), false, false);
	      this.add(typeof(RGR_RGR_DEFINTION), true, true);
	      this.add(typeof(DSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RGR_RGR - this is probably a bug in the source code generator.", e);
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

    /// <summary>   Returns MSA (Message Acknowledgment) - creates it if necessary. </summary>
    ///
    /// <value> The msa. </value>

	public MSA MSA { 
get{
	   MSA ret = null;
	   try {
	      ret = (MSA)this.GetStructure("MSA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>   Returns ERR (Error) - creates it if necessary. </summary>
    ///
    /// <value> The error. </value>

	public ERR ERR { 
get{
	   ERR ret = null;
	   try {
	      ret = (ERR)this.GetStructure("ERR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns  first repetition of RGR_RGR_DEFINTION (a Group object) - creates it if necessary.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <returns>   The defintion. </returns>

	public RGR_RGR_DEFINTION GetDEFINTION() {
	   RGR_RGR_DEFINTION ret = null;
	   try {
	      ret = (RGR_RGR_DEFINTION)this.GetStructure("DEFINTION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

    /// <summary>
    /// Returns a specific repetition of RGR_RGR_DEFINTION
    ///  * (a Group object) - creates it if necessary throws HL7Exception if the repetition requested
    ///  is more than one
    ///      greater than the number of existing repetitions.
    /// </summary>
    ///
    /// <param name="rep">  The rep. </param>
    ///
    /// <returns>   The defintion. </returns>

	public RGR_RGR_DEFINTION GetDEFINTION(int rep) { 
	   return (RGR_RGR_DEFINTION)this.GetStructure("DEFINTION", rep);
	}

    /// <summary>   Gets the defintion repetitions used. </summary>
    ///
    /// <value> The defintion repetitions used. </value>

	public int DEFINTIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DEFINTION").Length; 
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
