using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V24.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V24.Segment{

/// <summary>
/// Represents an HL7 PV2 message segment. This segment has the following fields:<ol>
/// <li>PV2-1: Prior Pending Location (PL)</li>
/// <li>PV2-2: Accommodation Code (CE)</li>
/// <li>PV2-3: Admit Reason (CE)</li>
/// <li>PV2-4: Transfer Reason (CE)</li>
/// <li>PV2-5: Patient Valuables (ST)</li>
/// <li>PV2-6: Patient Valuables Location (ST)</li>
/// <li>PV2-7: Visit User Code (IS)</li>
/// <li>PV2-8: Expected Admit Date/Time (TS)</li>
/// <li>PV2-9: Expected Discharge Date/Time (TS)</li>
/// <li>PV2-10: Estimated Length of Inpatient Stay (NM)</li>
/// <li>PV2-11: Actual Length of Inpatient Stay (NM)</li>
/// <li>PV2-12: Visit Description (ST)</li>
/// <li>PV2-13: Referral Source Code (XCN)</li>
/// <li>PV2-14: Previous Service Date (DT)</li>
/// <li>PV2-15: Employment Illness Related Indicator (ID)</li>
/// <li>PV2-16: Purge Status Code (IS)</li>
/// <li>PV2-17: Purge Status Date (DT)</li>
/// <li>PV2-18: Special Program Code (IS)</li>
/// <li>PV2-19: Retention Indicator (ID)</li>
/// <li>PV2-20: Expected Number of Insurance Plans (NM)</li>
/// <li>PV2-21: Visit Publicity Code (IS)</li>
/// <li>PV2-22: Visit Protection Indicator (ID)</li>
/// <li>PV2-23: Clinic Organization Name (XON)</li>
/// <li>PV2-24: Patient Status Code (IS)</li>
/// <li>PV2-25: Visit Priority Code (IS)</li>
/// <li>PV2-26: Previous Treatment Date (DT)</li>
/// <li>PV2-27: Expected Discharge Disposition (IS)</li>
/// <li>PV2-28: Signature on File Date (DT)</li>
/// <li>PV2-29: First Similar Illness Date (DT)</li>
/// <li>PV2-30: Patient Charge Adjustment Code (CE)</li>
/// <li>PV2-31: Recurring Service Code (IS)</li>
/// <li>PV2-32: Billing Media Code (ID)</li>
/// <li>PV2-33: Expected Surgery Date and Time (TS)</li>
/// <li>PV2-34: Military Partnership Code (ID)</li>
/// <li>PV2-35: Military Non-Availability Code (ID)</li>
/// <li>PV2-36: Newborn Baby Indicator (ID)</li>
/// <li>PV2-37: Baby Detained Indicator (ID)</li>
/// <li>PV2-38: Mode of Arrival Code (CE)</li>
/// <li>PV2-39: Recreational Drug Use Code (CE)</li>
/// <li>PV2-40: Admission Level of Care Code (CE)</li>
/// <li>PV2-41: Precaution Code (CE)</li>
/// <li>PV2-42: Patient Condition Code (CE)</li>
/// <li>PV2-43: Living Will Code (IS)</li>
/// <li>PV2-44: Organ Donor Code (IS)</li>
/// <li>PV2-45: Advance Directive Code (CE)</li>
/// <li>PV2-46: Patient Status Effective Date (DT)</li>
/// <li>PV2-47: Expected LOA Return Date/Time (TS)</li>
/// </ol>
/// The get...() methods return data from individual fields.  These methods do not throw
/// exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much an exceptional
/// circumstance as a bug in the code for this class.
/// </summary>

[Serializable]
public class PV2 : AbstractSegment  {

    /// <summary>   Initializes a new instance of the PV2 class. </summary>
    ///
    /// <param name="parent">   The parent. </param>
    /// <param name="factory">  The factory. </param>

	public PV2(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(PL), false, 1, 80, new System.Object[]{message}, "Prior Pending Location");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Accommodation Code");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Admit Reason");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Transfer Reason");
       this.add(typeof(ST), false, 0, 25, new System.Object[]{message}, "Patient Valuables");
       this.add(typeof(ST), false, 1, 25, new System.Object[]{message}, "Patient Valuables Location");
       this.add(typeof(IS), false, 0, 2, new System.Object[]{message, 130}, "Visit User Code");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Expected Admit Date/Time");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Expected Discharge Date/Time");
       this.add(typeof(NM), false, 1, 3, new System.Object[]{message}, "Estimated Length of Inpatient Stay");
       this.add(typeof(NM), false, 1, 3, new System.Object[]{message}, "Actual Length of Inpatient Stay");
       this.add(typeof(ST), false, 1, 50, new System.Object[]{message}, "Visit Description");
       this.add(typeof(XCN), false, 0, 250, new System.Object[]{message}, "Referral Source Code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Previous Service Date");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Employment Illness Related Indicator");
       this.add(typeof(IS), false, 1, 1, new System.Object[]{message, 213}, "Purge Status Code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Purge Status Date");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 214}, "Special Program Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Retention Indicator");
       this.add(typeof(NM), false, 1, 1, new System.Object[]{message}, "Expected Number of Insurance Plans");
       this.add(typeof(IS), false, 1, 1, new System.Object[]{message, 215}, "Visit Publicity Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Visit Protection Indicator");
       this.add(typeof(XON), false, 0, 250, new System.Object[]{message}, "Clinic Organization Name");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 216}, "Patient Status Code");
       this.add(typeof(IS), false, 1, 1, new System.Object[]{message, 217}, "Visit Priority Code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Previous Treatment Date");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 112}, "Expected Discharge Disposition");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Signature on File Date");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "First Similar Illness Date");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Patient Charge Adjustment Code");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 219}, "Recurring Service Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Billing Media Code");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Expected Surgery Date and Time");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Military Partnership Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Military Non-Availability Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Newborn Baby Indicator");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Baby Detained Indicator");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Mode of Arrival Code");
       this.add(typeof(CE), false, 0, 250, new System.Object[]{message}, "Recreational Drug Use Code");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Admission Level of Care Code");
       this.add(typeof(CE), false, 0, 250, new System.Object[]{message}, "Precaution Code");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Patient Condition Code");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 315}, "Living Will Code");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 316}, "Organ Donor Code");
       this.add(typeof(CE), false, 0, 250, new System.Object[]{message}, "Advance Directive Code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Patient Status Effective Date");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Expected LOA Return Date/Time");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

    /// <summary>   Returns Prior Pending Location(PV2-1). </summary>
    ///
    /// <value> The prior pending location. </value>

	public PL PriorPendingLocation
	{
		get{
			PL ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (PL)t;
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

    /// <summary>   Returns Accommodation Code(PV2-2). </summary>
    ///
    /// <value> The accommodation code. </value>

	public CE AccommodationCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (CE)t;
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

    /// <summary>   Returns Admit Reason(PV2-3). </summary>
    ///
    /// <value> The admit reason. </value>

	public CE AdmitReason
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(3, 0);
				ret = (CE)t;
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

    /// <summary>   Returns Transfer Reason(PV2-4). </summary>
    ///
    /// <value> The transfer reason. </value>

	public CE TransferReason
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(4, 0);
				ret = (CE)t;
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

    /// <summary>
    /// Returns a single repetition of Patient Valuables(PV2-5). throws HL7Exception if the
    /// repetition number is invalid.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <param name="rep">  The repetition number (this is a repeating field) </param>
    ///
    /// <returns>   The patient valuables. </returns>

	public ST GetPatientValuables(int rep)
	{
			ST ret = null;
			try
			{
			IType t = this.GetField(5, rep);
				ret = (ST)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  /// <summary> Returns all repetitions of Patient Valuables (PV2-5). </summary>
  ///
  /// <exception cref="Exception">  Thrown when an exception error condition occurs. </exception>
  ///
  /// <returns> An array of st. </returns>

  public ST[] GetPatientValuables() {
     ST[] ret = null;
    try {
        IType[] t = this.GetField(5);  
        ret = new ST[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (ST)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  /// <summary> Returns the total repetitions of Patient Valuables (PV2-5). </summary>
  ///
  /// <value>   The patient valuables repetitions used. </value>

  public int PatientValuablesRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(5);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}

    /// <summary>   Returns Patient Valuables Location(PV2-6). </summary>
    ///
    /// <value> The patient valuables location. </value>

	public ST PatientValuablesLocation
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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

    /// <summary>
    /// Returns a single repetition of Visit User Code(PV2-7). throws HL7Exception if the repetition
    /// number is invalid.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <param name="rep">  The repetition number (this is a repeating field) </param>
    ///
    /// <returns>   The visit user code. </returns>

	public IS GetVisitUserCode(int rep)
	{
			IS ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (IS)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  /// <summary> Returns all repetitions of Visit User Code (PV2-7). </summary>
  ///
  /// <exception cref="Exception">  Thrown when an exception error condition occurs. </exception>
  ///
  /// <returns> An array of is. </returns>

  public IS[] GetVisitUserCode() {
     IS[] ret = null;
    try {
        IType[] t = this.GetField(7);  
        ret = new IS[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (IS)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  /// <summary> Returns the total repetitions of Visit User Code (PV2-7). </summary>
  ///
  /// <value>   The visit user code repetitions used. </value>

  public int VisitUserCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(7);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}

    /// <summary>   Returns Expected Admit Date/Time(PV2-8). </summary>
    ///
    /// <value> The expected admit date time. </value>

	public TS ExpectedAdmitDateTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (TS)t;
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

    /// <summary>   Returns Expected Discharge Date/Time(PV2-9). </summary>
    ///
    /// <value> The expected discharge date time. </value>

	public TS ExpectedDischargeDateTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (TS)t;
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

    /// <summary>   Returns Estimated Length of Inpatient Stay(PV2-10). </summary>
    ///
    /// <value> The estimated length of inpatient stay. </value>

	public NM EstimatedLengthOfInpatientStay
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(10, 0);
				ret = (NM)t;
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

    /// <summary>   Returns Actual Length of Inpatient Stay(PV2-11). </summary>
    ///
    /// <value> The actual length of inpatient stay. </value>

	public NM ActualLengthOfInpatientStay
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(11, 0);
				ret = (NM)t;
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

    /// <summary>   Returns Visit Description(PV2-12). </summary>
    ///
    /// <value> Information describing the visit. </value>

	public ST VisitDescription
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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

    /// <summary>
    /// Returns a single repetition of Referral Source Code(PV2-13). throws HL7Exception if the
    /// repetition number is invalid.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <param name="rep">  The repetition number (this is a repeating field) </param>
    ///
    /// <returns>   The referral source code. </returns>

	public XCN GetReferralSourceCode(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(13, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  /// <summary> Returns all repetitions of Referral Source Code (PV2-13). </summary>
  ///
  /// <exception cref="Exception">  Thrown when an exception error condition occurs. </exception>
  ///
  /// <returns> An array of xcn. </returns>

  public XCN[] GetReferralSourceCode() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(13);  
        ret = new XCN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XCN)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  /// <summary> Returns the total repetitions of Referral Source Code (PV2-13). </summary>
  ///
  /// <value>   The referral source code repetitions used. </value>

  public int ReferralSourceCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(13);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}

    /// <summary>   Returns Previous Service Date(PV2-14). </summary>
    ///
    /// <value> The previous service date. </value>

	public DT PreviousServiceDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(14, 0);
				ret = (DT)t;
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

    /// <summary>   Returns Employment Illness Related Indicator(PV2-15). </summary>
    ///
    /// <value> The employment illness related indicator. </value>

	public ID EmploymentIllnessRelatedIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(15, 0);
				ret = (ID)t;
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

    /// <summary>   Returns Purge Status Code(PV2-16). </summary>
    ///
    /// <value> The purge status code. </value>

	public IS PurgeStatusCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(16, 0);
				ret = (IS)t;
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

    /// <summary>   Returns Purge Status Date(PV2-17). </summary>
    ///
    /// <value> The purge status date. </value>

	public DT PurgeStatusDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(17, 0);
				ret = (DT)t;
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

    /// <summary>   Returns Special Program Code(PV2-18). </summary>
    ///
    /// <value> The special program code. </value>

	public IS SpecialProgramCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(18, 0);
				ret = (IS)t;
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

    /// <summary>   Returns Retention Indicator(PV2-19). </summary>
    ///
    /// <value> The retention indicator. </value>

	public ID RetentionIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(19, 0);
				ret = (ID)t;
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

    /// <summary>   Returns Expected Number of Insurance Plans(PV2-20). </summary>
    ///
    /// <value> The expected number of insurance plans. </value>

	public NM ExpectedNumberOfInsurancePlans
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(20, 0);
				ret = (NM)t;
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

    /// <summary>   Returns Visit Publicity Code(PV2-21). </summary>
    ///
    /// <value> The visit publicity code. </value>

	public IS VisitPublicityCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(21, 0);
				ret = (IS)t;
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

    /// <summary>   Returns Visit Protection Indicator(PV2-22). </summary>
    ///
    /// <value> The visit protection indicator. </value>

	public ID VisitProtectionIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(22, 0);
				ret = (ID)t;
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

    /// <summary>
    /// Returns a single repetition of Clinic Organization Name(PV2-23). throws HL7Exception if the
    /// repetition number is invalid.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <param name="rep">  The repetition number (this is a repeating field) </param>
    ///
    /// <returns>   The clinic organization name. </returns>

	public XON GetClinicOrganizationName(int rep)
	{
			XON ret = null;
			try
			{
			IType t = this.GetField(23, rep);
				ret = (XON)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  /// <summary> Returns all repetitions of Clinic Organization Name (PV2-23). </summary>
  ///
  /// <exception cref="Exception">  Thrown when an exception error condition occurs. </exception>
  ///
  /// <returns> An array of XON. </returns>

  public XON[] GetClinicOrganizationName() {
     XON[] ret = null;
    try {
        IType[] t = this.GetField(23);  
        ret = new XON[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XON)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  /// <summary> Returns the total repetitions of Clinic Organization Name (PV2-23). </summary>
  ///
  /// <value>   The clinic organization name repetitions used. </value>

  public int ClinicOrganizationNameRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(23);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}

    /// <summary>   Returns Patient Status Code(PV2-24). </summary>
    ///
    /// <value> The patient status code. </value>

	public IS PatientStatusCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(24, 0);
				ret = (IS)t;
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

    /// <summary>   Returns Visit Priority Code(PV2-25). </summary>
    ///
    /// <value> The visit priority code. </value>

	public IS VisitPriorityCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(25, 0);
				ret = (IS)t;
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

    /// <summary>   Returns Previous Treatment Date(PV2-26). </summary>
    ///
    /// <value> The previous treatment date. </value>

	public DT PreviousTreatmentDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(26, 0);
				ret = (DT)t;
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

    /// <summary>   Returns Expected Discharge Disposition(PV2-27). </summary>
    ///
    /// <value> The expected discharge disposition. </value>

	public IS ExpectedDischargeDisposition
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(27, 0);
				ret = (IS)t;
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

    /// <summary>   Returns Signature on File Date(PV2-28). </summary>
    ///
    /// <value> The signature on file date. </value>

	public DT SignatureOnFileDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(28, 0);
				ret = (DT)t;
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

    /// <summary>   Returns First Similar Illness Date(PV2-29). </summary>
    ///
    /// <value> The first similar illness date. </value>

	public DT FirstSimilarIllnessDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(29, 0);
				ret = (DT)t;
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

    /// <summary>   Returns Patient Charge Adjustment Code(PV2-30). </summary>
    ///
    /// <value> The patient charge adjustment code. </value>

	public CE PatientChargeAdjustmentCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(30, 0);
				ret = (CE)t;
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

    /// <summary>   Returns Recurring Service Code(PV2-31). </summary>
    ///
    /// <value> The recurring service code. </value>

	public IS RecurringServiceCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(31, 0);
				ret = (IS)t;
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

    /// <summary>   Returns Billing Media Code(PV2-32). </summary>
    ///
    /// <value> The billing media code. </value>

	public ID BillingMediaCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(32, 0);
				ret = (ID)t;
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

    /// <summary>   Returns Expected Surgery Date and Time(PV2-33). </summary>
    ///
    /// <value> The expected surgery date and time. </value>

	public TS ExpectedSurgeryDateAndTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(33, 0);
				ret = (TS)t;
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

    /// <summary>   Returns Military Partnership Code(PV2-34). </summary>
    ///
    /// <value> The military partnership code. </value>

	public ID MilitaryPartnershipCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(34, 0);
				ret = (ID)t;
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

    /// <summary>   Returns Military Non-Availability Code(PV2-35). </summary>
    ///
    /// <value> The military non availability code. </value>

	public ID MilitaryNonAvailabilityCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(35, 0);
				ret = (ID)t;
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

    /// <summary>   Returns Newborn Baby Indicator(PV2-36). </summary>
    ///
    /// <value> The newborn baby indicator. </value>

	public ID NewbornBabyIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(36, 0);
				ret = (ID)t;
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

    /// <summary>   Returns Baby Detained Indicator(PV2-37). </summary>
    ///
    /// <value> The baby detained indicator. </value>

	public ID BabyDetainedIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(37, 0);
				ret = (ID)t;
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

    /// <summary>   Returns Mode of Arrival Code(PV2-38). </summary>
    ///
    /// <value> The mode of arrival code. </value>

	public CE ModeOfArrivalCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(38, 0);
				ret = (CE)t;
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

    /// <summary>
    /// Returns a single repetition of Recreational Drug Use Code(PV2-39). throws HL7Exception if the
    /// repetition number is invalid.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <param name="rep">  The repetition number (this is a repeating field) </param>
    ///
    /// <returns>   The recreational drug use code. </returns>

	public CE GetRecreationalDrugUseCode(int rep)
	{
			CE ret = null;
			try
			{
			IType t = this.GetField(39, rep);
				ret = (CE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  /// <summary> Returns all repetitions of Recreational Drug Use Code (PV2-39). </summary>
  ///
  /// <exception cref="Exception">  Thrown when an exception error condition occurs. </exception>
  ///
  /// <returns> An array of ce. </returns>

  public CE[] GetRecreationalDrugUseCode() {
     CE[] ret = null;
    try {
        IType[] t = this.GetField(39);  
        ret = new CE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CE)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  /// <summary> Returns the total repetitions of Recreational Drug Use Code (PV2-39). </summary>
  ///
  /// <value>   The recreational drug use code repetitions used. </value>

  public int RecreationalDrugUseCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(39);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}

    /// <summary>   Returns Admission Level of Care Code(PV2-40). </summary>
    ///
    /// <value> The admission level of care code. </value>

	public CE AdmissionLevelOfCareCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(40, 0);
				ret = (CE)t;
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

    /// <summary>
    /// Returns a single repetition of Precaution Code(PV2-41). throws HL7Exception if the repetition
    /// number is invalid.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <param name="rep">  The repetition number (this is a repeating field) </param>
    ///
    /// <returns>   The precaution code. </returns>

	public CE GetPrecautionCode(int rep)
	{
			CE ret = null;
			try
			{
			IType t = this.GetField(41, rep);
				ret = (CE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  /// <summary> Returns all repetitions of Precaution Code (PV2-41). </summary>
  ///
  /// <exception cref="Exception">  Thrown when an exception error condition occurs. </exception>
  ///
  /// <returns> An array of ce. </returns>

  public CE[] GetPrecautionCode() {
     CE[] ret = null;
    try {
        IType[] t = this.GetField(41);  
        ret = new CE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CE)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  /// <summary> Returns the total repetitions of Precaution Code (PV2-41). </summary>
  ///
  /// <value>   The precaution code repetitions used. </value>

  public int PrecautionCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(41);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}

    /// <summary>   Returns Patient Condition Code(PV2-42). </summary>
    ///
    /// <value> The patient condition code. </value>

	public CE PatientConditionCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(42, 0);
				ret = (CE)t;
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

    /// <summary>   Returns Living Will Code(PV2-43). </summary>
    ///
    /// <value> The living will code. </value>

	public IS LivingWillCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(43, 0);
				ret = (IS)t;
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

    /// <summary>   Returns Organ Donor Code(PV2-44). </summary>
    ///
    /// <value> The organ donor code. </value>

	public IS OrganDonorCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(44, 0);
				ret = (IS)t;
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

    /// <summary>
    /// Returns a single repetition of Advance Directive Code(PV2-45). throws HL7Exception if the
    /// repetition number is invalid.
    /// </summary>
    ///
    /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
    ///
    /// <param name="rep">  The repetition number (this is a repeating field) </param>
    ///
    /// <returns>   The advance directive code. </returns>

	public CE GetAdvanceDirectiveCode(int rep)
	{
			CE ret = null;
			try
			{
			IType t = this.GetField(45, rep);
				ret = (CE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  /// <summary> Returns all repetitions of Advance Directive Code (PV2-45). </summary>
  ///
  /// <exception cref="Exception">  Thrown when an exception error condition occurs. </exception>
  ///
  /// <returns> An array of ce. </returns>

  public CE[] GetAdvanceDirectiveCode() {
     CE[] ret = null;
    try {
        IType[] t = this.GetField(45);  
        ret = new CE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CE)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  /// <summary> Returns the total repetitions of Advance Directive Code (PV2-45). </summary>
  ///
  /// <value>   The advance directive code repetitions used. </value>

  public int AdvanceDirectiveCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(45);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}

    /// <summary>   Returns Patient Status Effective Date(PV2-46). </summary>
    ///
    /// <value> The patient status effective date. </value>

	public DT PatientStatusEffectiveDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(46, 0);
				ret = (DT)t;
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

    /// <summary>   Returns Expected LOA Return Date/Time(PV2-47). </summary>
    ///
    /// <value> The expected loa return date time. </value>

	public TS ExpectedLOAReturnDateTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(47, 0);
				ret = (TS)t;
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