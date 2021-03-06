using System;
using NHapi.Base.Model;
using NHapi.Base;
using NHapi.Base.Model.Primitive;
namespace NHapi.Model.V22.Datatype
{
/// <summary>
/// Represents the HL7 TX (text data) datatype.  A TX contains a single String value.
/// </summary>

[Serializable]
public class TX : AbstractPrimitive  {

    /// <summary>   Constructs an uninitialized TX. </summary>
    ///
    /// <param name="message">  The Message to which this Type belongs. </param>

	public TX(IMessage message) : base(message){
	}

    /// <summary>   Constructs an uninitialized TX. </summary>
    ///
    /// <param name="message">      The Message to which this Type belongs. </param>
    /// <param name="description">  The description of this type. </param>

	public TX(IMessage message, string description) : base(message,description){
	}

    /// <summary>   @return "2.2". </summary>
    ///
    /// <returns>   The version. </returns>

	public string getVersion() {
	    return "2.2";
}
}
}