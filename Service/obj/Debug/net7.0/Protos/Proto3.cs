// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/proto3.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from Protos/proto3.proto</summary>
public static partial class Proto3Reflection {

  #region Descriptor
  /// <summary>File descriptor for Protos/proto3.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static Proto3Reflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChNQcm90b3MvcHJvdG8zLnByb3RvGhtnb29nbGUvcHJvdG9idWYvZW1wdHku",
          "cHJvdG8aHmdvb2dsZS9wcm90b2J1Zi93cmFwcGVycy5wcm90byJnCgxFdmVu",
          "dFJlcXVlc3QSDAoEbmFtZRgBIAEoCRITCgtkZXNjcmlwdGlvbhgCIAEoCRIT",
          "CgtFbnRlcnRhaW5lchgDIAEoCRIRCglDYWZlT3duZXIYBSABKAkSDAoERGF0",
          "ZRgGIAEoCSJTCg1FdmVudFJlc3BvbnNlEgoKAmlkGAEgASgJEgwKBG5hbWUY",
          "AiABKAkSEwoLZGVzY3JpcHRpb24YAyABKAkSEwoLRW50ZXJ0YWluZXIYBCAB",
          "KAkyPgoMRXZlbnRTZXJ2aWNlEi4KC0NyZWF0ZUV2ZW50Eg0uRXZlbnRSZXF1",
          "ZXN0Gg4uRXZlbnRSZXNwb25zZSIAQh8KD2dyb3VwNy5wcm90b2J1ZkIKRXZl",
          "bnRQcm90b1ABYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::EventRequest), global::EventRequest.Parser, new[]{ "Name", "Description", "Entertainer", "CafeOwner", "Date" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::EventResponse), global::EventResponse.Parser, new[]{ "Id", "Name", "Description", "Entertainer" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class EventRequest : pb::IMessage<EventRequest>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<EventRequest> _parser = new pb::MessageParser<EventRequest>(() => new EventRequest());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<EventRequest> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::Proto3Reflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public EventRequest() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public EventRequest(EventRequest other) : this() {
    name_ = other.name_;
    description_ = other.description_;
    entertainer_ = other.entertainer_;
    cafeOwner_ = other.cafeOwner_;
    date_ = other.date_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public EventRequest Clone() {
    return new EventRequest(this);
  }

  /// <summary>Field number for the "name" field.</summary>
  public const int NameFieldNumber = 1;
  private string name_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Name {
    get { return name_; }
    set {
      name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "description" field.</summary>
  public const int DescriptionFieldNumber = 2;
  private string description_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Description {
    get { return description_; }
    set {
      description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "Entertainer" field.</summary>
  public const int EntertainerFieldNumber = 3;
  private string entertainer_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Entertainer {
    get { return entertainer_; }
    set {
      entertainer_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "CafeOwner" field.</summary>
  public const int CafeOwnerFieldNumber = 5;
  private string cafeOwner_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string CafeOwner {
    get { return cafeOwner_; }
    set {
      cafeOwner_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "Date" field.</summary>
  public const int DateFieldNumber = 6;
  private string date_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Date {
    get { return date_; }
    set {
      date_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as EventRequest);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(EventRequest other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Name != other.Name) return false;
    if (Description != other.Description) return false;
    if (Entertainer != other.Entertainer) return false;
    if (CafeOwner != other.CafeOwner) return false;
    if (Date != other.Date) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Name.Length != 0) hash ^= Name.GetHashCode();
    if (Description.Length != 0) hash ^= Description.GetHashCode();
    if (Entertainer.Length != 0) hash ^= Entertainer.GetHashCode();
    if (CafeOwner.Length != 0) hash ^= CafeOwner.GetHashCode();
    if (Date.Length != 0) hash ^= Date.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Name.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Name);
    }
    if (Description.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Description);
    }
    if (Entertainer.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(Entertainer);
    }
    if (CafeOwner.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(CafeOwner);
    }
    if (Date.Length != 0) {
      output.WriteRawTag(50);
      output.WriteString(Date);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Name.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Name);
    }
    if (Description.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Description);
    }
    if (Entertainer.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(Entertainer);
    }
    if (CafeOwner.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(CafeOwner);
    }
    if (Date.Length != 0) {
      output.WriteRawTag(50);
      output.WriteString(Date);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Name.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
    }
    if (Description.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
    }
    if (Entertainer.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Entertainer);
    }
    if (CafeOwner.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(CafeOwner);
    }
    if (Date.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Date);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(EventRequest other) {
    if (other == null) {
      return;
    }
    if (other.Name.Length != 0) {
      Name = other.Name;
    }
    if (other.Description.Length != 0) {
      Description = other.Description;
    }
    if (other.Entertainer.Length != 0) {
      Entertainer = other.Entertainer;
    }
    if (other.CafeOwner.Length != 0) {
      CafeOwner = other.CafeOwner;
    }
    if (other.Date.Length != 0) {
      Date = other.Date;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Name = input.ReadString();
          break;
        }
        case 18: {
          Description = input.ReadString();
          break;
        }
        case 26: {
          Entertainer = input.ReadString();
          break;
        }
        case 42: {
          CafeOwner = input.ReadString();
          break;
        }
        case 50: {
          Date = input.ReadString();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Name = input.ReadString();
          break;
        }
        case 18: {
          Description = input.ReadString();
          break;
        }
        case 26: {
          Entertainer = input.ReadString();
          break;
        }
        case 42: {
          CafeOwner = input.ReadString();
          break;
        }
        case 50: {
          Date = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

public sealed partial class EventResponse : pb::IMessage<EventResponse>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<EventResponse> _parser = new pb::MessageParser<EventResponse>(() => new EventResponse());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<EventResponse> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::Proto3Reflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public EventResponse() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public EventResponse(EventResponse other) : this() {
    id_ = other.id_;
    name_ = other.name_;
    description_ = other.description_;
    entertainer_ = other.entertainer_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public EventResponse Clone() {
    return new EventResponse(this);
  }

  /// <summary>Field number for the "id" field.</summary>
  public const int IdFieldNumber = 1;
  private string id_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Id {
    get { return id_; }
    set {
      id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "name" field.</summary>
  public const int NameFieldNumber = 2;
  private string name_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Name {
    get { return name_; }
    set {
      name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "description" field.</summary>
  public const int DescriptionFieldNumber = 3;
  private string description_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Description {
    get { return description_; }
    set {
      description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "Entertainer" field.</summary>
  public const int EntertainerFieldNumber = 4;
  private string entertainer_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Entertainer {
    get { return entertainer_; }
    set {
      entertainer_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as EventResponse);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(EventResponse other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Id != other.Id) return false;
    if (Name != other.Name) return false;
    if (Description != other.Description) return false;
    if (Entertainer != other.Entertainer) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Id.Length != 0) hash ^= Id.GetHashCode();
    if (Name.Length != 0) hash ^= Name.GetHashCode();
    if (Description.Length != 0) hash ^= Description.GetHashCode();
    if (Entertainer.Length != 0) hash ^= Entertainer.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Id.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Id);
    }
    if (Name.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Name);
    }
    if (Description.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(Description);
    }
    if (Entertainer.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(Entertainer);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Id.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Id);
    }
    if (Name.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Name);
    }
    if (Description.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(Description);
    }
    if (Entertainer.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(Entertainer);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Id.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
    }
    if (Name.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
    }
    if (Description.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
    }
    if (Entertainer.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Entertainer);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(EventResponse other) {
    if (other == null) {
      return;
    }
    if (other.Id.Length != 0) {
      Id = other.Id;
    }
    if (other.Name.Length != 0) {
      Name = other.Name;
    }
    if (other.Description.Length != 0) {
      Description = other.Description;
    }
    if (other.Entertainer.Length != 0) {
      Entertainer = other.Entertainer;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Id = input.ReadString();
          break;
        }
        case 18: {
          Name = input.ReadString();
          break;
        }
        case 26: {
          Description = input.ReadString();
          break;
        }
        case 34: {
          Entertainer = input.ReadString();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Id = input.ReadString();
          break;
        }
        case 18: {
          Name = input.ReadString();
          break;
        }
        case 26: {
          Description = input.ReadString();
          break;
        }
        case 34: {
          Entertainer = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code