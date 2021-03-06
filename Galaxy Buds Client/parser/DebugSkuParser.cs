﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Galaxy_Buds_Client.message;

namespace Galaxy_Buds_Client.parser
{
    class DebugSkuParser : BaseMessageParser
    {
        public override SPPMessage.MessageIds HandledType => SPPMessage.MessageIds.MSG_ID_DEBUG_SKU;

        public char a { set; get; }
        public char b { set; get; }
        public char c { set; get; }
        public char d { set; get; }
        public override void ParseMessage(SPPMessage msg)
        {
            if (msg.Id != HandledType)
                return;

            a = (char)msg.Payload[12];
            b = (char)msg.Payload[13];
            c = (char)msg.Payload[26];
            d = (char)msg.Payload[27];
        }

        public override Dictionary<String, String> ToStringMap()
        {
            Dictionary<String, String> map = new Dictionary<string, string>();
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "HandledType" || property.Name == "ActiveModel")
                    continue;

                map.Add(property.Name, property.GetValue(this).ToString());
            }

            return map;
        }
    }
}
