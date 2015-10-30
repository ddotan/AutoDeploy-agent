using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AutoDeploy.Application.Objects
{
    [Serializable]
    [XmlRoot("EndPoint")]
    public class EndpointInfo
    {
        [XmlElement("Name")]

        public string Component { get; set; }
        [XmlElement("URI")]
        public string Address { get; set; }



    }
}
