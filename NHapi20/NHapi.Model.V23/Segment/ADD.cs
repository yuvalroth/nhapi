using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V23.Segment{

/// <summary>
/// Represents an HL7 ADD message segment. This segment has the following fields:<ol>
/// <li>ADD-1: Addendum Continuation Pointer (ST)</li>
/// </ol>
/// The get...() methods return data from individual fields.  These methods do not throw
/// exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much an exceptional
/// circumstance as a bug in the code for this class.
/// </summary>

[Serializable]
public class ADD : AbstractSegment  {

    /// <summary>   Initializes a new instance of the ADD class. </summary>
    ///
    /// <param name="parent">   The parent. </param>
    /// <param name="factory">  The factory. </param>

	public ADD(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(ST), false, 1, 65536, new System.Object[]{message}, "Addendum Continuation Pointer");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

    /// <summary>   Returns Addendum Continuation Pointer(ADD-1). </summary>
    ///
    /// <value> The addendum continuation pointer. </value>

	public ST AddendumContinuationPointer
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (ST)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }


}}