using System;
using NHapi.Base.Model;
using NHapi.Base;
using NHapi.Base.Model.Primitive;
namespace NHapi.Model.V22.Datatype
{
/// <summary>
/// Represents the HL7 SI (SEQUENCE ID) datatype.  A SI contains a single String value.
/// </summary>

[Serializable]
public class SI : AbstractPrimitive  {

    /// <summary>   Constructs an uninitialized SI. </summary>
    ///
    /// <param name="message">  The Message to which this Type belongs. </param>

	public SI(IMessage message) : base(message){
	}

    /// <summary>   Constructs an uninitialized SI. </summary>
    ///
    /// <param name="message">      The Message to which this Type belongs. </param>
    /// <param name="description">  The description of this type. </param>

	public SI(IMessage message, string description) : base(message,description){
	}

    /// <summary>   @return "2.2". </summary>
    ///
    /// <returns>   The version. </returns>

	public string getVersion() {
	    return "2.2";
}
}
}