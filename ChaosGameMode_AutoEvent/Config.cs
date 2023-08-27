using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosGameMode_AutoEvent
{
    public sealed class Config : IConfig
    {
        [Description("Wheter the plugin is Enabled or not.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not debug messages should be shown in the console.")]
        public bool Debug { get; set; } = false;

        [Description("Time between Chaotic Waves.")]
        public static float TimeBetweenChaoticWaves = 10;

    }
}
