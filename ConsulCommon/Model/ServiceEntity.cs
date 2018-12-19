using System;
namespace ConsulCommon.Model
{
    public class ServiceEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value>The ip.</value>
        public string IP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>The port.</value>
        public int Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>The name of the service.</value>
        public string ServiceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>The consul ip.</value>
        public string ConsulIP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>The consul port.</value>
        public int ConsulPort { get; set; }
    }
}
