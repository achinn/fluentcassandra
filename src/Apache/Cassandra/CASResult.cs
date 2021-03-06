/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */

using System;
using System.Collections.Generic;
using System.Text;
using FluentCassandra.Thrift.Protocol;

namespace FluentCassandra.Apache.Cassandra
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class CASResult : TBase
  {
    private List<Column> _current_values;

    public bool Success { get; set; }

    public List<Column> Current_values
    {
      get
      {
        return _current_values;
      }
      set
      {
        __isset.current_values = true;
        this._current_values = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool current_values;
    }

    public CASResult() {
    }

    public CASResult(bool success) : this() {
      this.Success = success;
    }

    public void Read (TProtocol iprot)
    {
      bool isset_success = false;
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.Bool) {
              Success = iprot.ReadBool();
              isset_success = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.List) {
              {
                Current_values = new List<Column>();
                TList _list24 = iprot.ReadListBegin();
                for( int _i25 = 0; _i25 < _list24.Count; ++_i25)
                {
                  Column _elem26 = new Column();
                  _elem26 = new Column();
                  _elem26.Read(iprot);
                  Current_values.Add(_elem26);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
      if (!isset_success)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("CASResult");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "success";
      field.Type = TType.Bool;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteBool(Success);
      oprot.WriteFieldEnd();
      if (Current_values != null && __isset.current_values) {
        field.Name = "current_values";
        field.Type = TType.List;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Current_values.Count));
          foreach (Column _iter27 in Current_values)
          {
            _iter27.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("CASResult(");
      sb.Append("Success: ");
      sb.Append(Success);
      sb.Append(",Current_values: ");
      sb.Append(Current_values);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
