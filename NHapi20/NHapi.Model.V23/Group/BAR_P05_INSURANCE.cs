using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V23.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V23.Group
{
/// <summary>
/// Represents the BAR_P05_INSURANCE Group.  A Group is an ordered collection of message
///  segments that can repeat together or be optionally in/excluded together. This Group contains
///  the following elements:
/// <ol>
/// <li>0: IN1 (Insurance) </li>
/// <li>1: IN2 (Insurance additional info) optional </li>
/// <li>2: IN3 (Insurance additional info - certification) optional </li>
/// </ol>
/// </summary>

[Serializable]
public class BAR_P05_INSURANCE : AbstractGroup {

    /// <summary>   Creates a new BAR_P05_INSURANCE Group. </summary>
    ///
    /// <param name="parent">   The parent. </param>
    /// <param name="factory">  The factory. </param>

	public BAR_P05_INSURANCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(IN1), true, false);
	      this.add(typeof(IN2), false, false);
	      this.add(typeof(IN3), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating BAR_P05_INSURANCE - this is probably a bug in the source code generator.", e);
	   }
	}

    /// <summary>   Returns IN1 (Insurance) - creates it if necessary. </summary>
    ///
    /// <value> The in 1. </value>

	public IN1 IN1 { 
get{
	   IN1 ret = null;
	   try {
	      ret = (IN1)this.GetStructure("IN1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>   Returns IN2 (Insurance additional info) - creates it if necessary. </summary>
    ///
    /// <value> The in 2. </value>

	public IN2 IN2 { 
get{
	   IN2 ret = null;
	   try {
	      ret = (IN2)this.GetStructure("IN2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

    /// <summary>
    /// Returns IN3 (Insurance additional info - certification) - creates it if necessary.
    /// </summary>
    ///
    /// <value> The in 3. </value>

	public IN3 IN3 { 
get{
	   IN3 ret = null;
	   try {
	      ret = (IN3)this.GetStructure("IN3");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
