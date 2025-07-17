
namespace SpaceStation.Models.Domain
{
    public class NearEarthObject : BaseResponse
    {
        public Links links { get; set; }
        public string id { get; set; } = string.Empty;
        public string neo_reference_id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string name_limited { get; set; } = string.Empty;
        public string designation { get; set; } = string.Empty;
        public string nasa_jpl_url { get; set; } = string.Empty;
        public double absolute_magnitude_h { get; set; }
        public EstimatedDiameter estimated_diameter { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public List<CloseApproachDatum> close_approach_data { get; set; }
        public OrbitalData orbital_data { get; set; }
        public bool is_sentry_object { get; set; }
    }

    public class CloseApproachDatum
    {
        public string close_approach_date { get; set; } = string.Empty;
        public string close_approach_date_full { get; set; } = string.Empty;
        public object epoch_date_close_approach { get; set; } = string.Empty;  
        public RelativeVelocity relative_velocity { get; set; }
        public MissDistance miss_distance { get; set; }
        public string orbiting_body { get; set; } = string.Empty;
    }

    public class EstimatedDiameter
    {
        public MinMaxDiameter kilometers { get; set; }
        public MinMaxDiameter meters { get; set; }
        public MinMaxDiameter miles { get; set; }
        public MinMaxDiameter feet { get; set; }
    }

    public class MinMaxDiameter
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class MissDistance
    {
        public string astronomical { get; set; } = string.Empty;
        public string lunar { get; set; } = string.Empty;
        public string kilometers { get; set; } = string.Empty;
        public string miles { get; set; } = string.Empty;
    }

    public class OrbitalData
    {
        public string orbit_id { get; set; } = string.Empty;
        public string orbit_determination_date { get; set; } = string.Empty;
        public string first_observation_date { get; set; } = string.Empty;
        public string last_observation_date { get; set; } = string.Empty;
        public int data_arc_in_days { get; set; }
        public int observations_used { get; set; }
        public string orbit_uncertainty { get; set; } = string.Empty;
        public string minimum_orbit_intersection { get; set; } = string.Empty;
        public string jupiter_tisserand_invariant { get; set; } = string.Empty;
        public string epoch_osculation { get; set; } = string.Empty;
        public string eccentricity { get; set; } = string.Empty;
        public string semi_major_axis { get; set; } = string.Empty;
        public string inclination { get; set; } = string.Empty;
        public string ascending_node_longitude { get; set; } = string.Empty;
        public string orbital_period { get; set; } = string.Empty;
        public string perihelion_distance { get; set; } = string.Empty;
        public string perihelion_argument { get; set; } = string.Empty;
        public string aphelion_distance { get; set; } = string.Empty;
        public string perihelion_time { get; set; } = string.Empty;
        public string mean_anomaly { get; set; } = string.Empty;
        public string mean_motion { get; set; } = string.Empty;
        public string equinox { get; set; } = string.Empty;
        public OrbitClass orbit_class { get; set; }
    }

    public class OrbitClass
    {
        public string orbit_class_type { get; set; } = string.Empty;
        public string orbit_class_description { get; set; } = string.Empty;
        public string orbit_class_range { get; set; } = string.Empty;
    }

    public class RelativeVelocity
    {
        public string kilometers_per_second { get; set; } = string.Empty;
        public string kilometers_per_hour { get; set; } = string.Empty;
        public string miles_per_hour { get; set; } = string.Empty;
    }
}