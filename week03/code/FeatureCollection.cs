
//mirror the structure at USGA for their JSON data
// FeatureCollection:
//     metadata: {json data...}
//     bbox: [values]
//     features: [
//              {properties: {json data...}} 
//              {geometry: {json data...}},
//              id: String ]
//     

using System.ComponentModel;

public class FeatureCollection
{
    //Create a list of Features
    public List<Feature> Features { get; set; }
}

//feature class for next level of objects under FeatureCollection
public class Feature
{
        public Property Properties { get; set; }
}

//Properties for next level of objects under Features
public class Property
{
    public decimal mag;
    public string place;
}