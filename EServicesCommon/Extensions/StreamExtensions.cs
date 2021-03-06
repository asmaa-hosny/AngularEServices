﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EServicesCommon.Extensions
{
    public static class StreamExtensions
    {
       public static T ReadAndDeserializedFromJson<T>(this Stream stream)
        {
            if(stream==null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if(!stream.CanRead)
            {
                throw new NotSupportedException("Can't read from this stream.");
            }

            using (var streamreader= new StreamReader(stream))
            {
                using (var jsonTextReader = new JsonTextReader(streamreader))
                {
                    var jsonSerializer = new JsonSerializer();
                    return jsonSerializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public static void SerializeToJsonAndWrite<T>(this Stream stream, T objectToWrite)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (!stream.CanWrite)
            {
                throw new NotSupportedException("Can't write to this stream.");
            }
            using (var streaWriter = new StreamWriter(stream, new UTF8Encoding(), 1024, true))
            {
                using (var jsonTextWriter = new JsonTextWriter(streaWriter))
                {
                    var jsonSerializer = new JsonSerializer();
                    jsonSerializer.Serialize(jsonTextWriter, objectToWrite);
                    jsonTextWriter.Flush();
                }

            }

        }
    }
}
