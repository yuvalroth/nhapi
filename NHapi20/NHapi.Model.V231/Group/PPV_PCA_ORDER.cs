using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V231.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
/// <summary>
/// Represents the PPV_PCA_ORDER Group.  A Group is an ordered collection of message
///  segments that can repeat together or be optionally in/excluded together. This Group contains
///  the following elements:
/// <ol>
/// <li>0: ORC (ORC - common order segment) </li>
/// <li>1: PPV_PCA_ORDER_DETAIL (a Group object) optional </li>
/// </ol>
/// </summary>

[Serializable]
public class PPV_PCA_ORDER : AbstractGroup {

    /// <summary>   Creates a new PPV_PCA_ORDER Group. </summary>
    ///
    /// <param name="parent">   The parent. </param>
    /// <param name="factory">  The factory. </param>

	public PPV_PCA_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(PPV_PCA_ORDER_DETAIL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PPV_PCA_ORDER - this is probably a bug in the source code generator.", e);
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

    /// <summary>   Returns PPV_PCA_ORDER_DETAIL (a Group object) - creates it if necessary. </summary>
    ///
    /// <value> The order detail. </value>

	public PPV_PCA_ORDER_DETAIL ORDER_DETAIL { 
get{
	   PPV_PCA_ORDER_DETAIL ret = null;
	   try {
	      ret = (PPV_PCA_ORDER_DETAIL)this.GetStructure("ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
