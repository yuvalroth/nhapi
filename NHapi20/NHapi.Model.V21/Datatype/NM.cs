using System;
using NHapi.Base.Model;
using NHapi.Base;
using NHapi.Base.Model.Primitive;
namespace NHapi.Model.V21.Datatype
{
/// <summary>
/// Represents the HL7 NM (numeric) datatype.  A NM contains a single String value.
/// </summary>

[Serializable]
public class NM : AbstractPrimitive  {

    /// <summary>   Constructs an uninitialized NM. </summary>
    ///
    /// <param name="message">  The Message to which this Type belongs. </param>

	public NM(IMessage message) : base(message){
	}

    /// <summary>   Constructs an uninitialized NM. </summary>
    ///
    /// <param name="message">      The Message to which this Type belongs. </param>
    /// <param name="description">  The description of this type. </param>

	public NM(IMessage message, string description) : base(message,description){
	}

    /// <summary>   @return "2.1". </summary>
    ///
    /// <returns>   The version. </returns>

	public string getVersion() {
	    return "2.1";
}
}
}