﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MushroomServer.Models.Characters
{
    public class Peach : Character
    {
        public Peach() : base("Peach", 100, 0, "Magic Abilities") { }

        public static string Art = """
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;234;48;5;234m▓[38;5;242;48;5;241m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;242;48;5;241m▓[38;5;243;48;5;242m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;33;48;5;33m [38;5;221;48;5;220m [38;5;226;48;5;226m [38;5;210;48;5;210m [38;5;209;48;5;209m░[38;5;32;48;5;31m░[38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;102;48;5;102m▓[38;5;172;48;5;94m▒[38;5;186;48;5;3m▒[38;5;130;48;5;94m▒[38;5;202;48;5;95m▒[38;5;172;48;5;94m▒[38;5;16;48;5;16m▓[38;5;67;48;5;245m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;136;48;5;220m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;221;48;5;214m [38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;234;48;5;234m▓[38;5;94;48;5;179m▒[38;5;185;48;5;185m▒[38;5;185;48;5;185m▒[38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;220;48;5;220m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;94;48;5;58m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;94;48;5;214m [38;5;221;48;5;220m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;172;48;5;58m░[38;5;16;48;5;16m▓[38;5;221;48;5;214m [38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;136;48;5;220m [38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;226;48;5;226m [38;5;130;48;5;58m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;52;48;5;232m [38;5;94;48;5;221m [38;5;52;48;5;16m [38;5;52;48;5;16m [38;5;227;48;5;227m [38;5;136;48;5;101m▓[38;5;229;48;5;229m [38;5;52;48;5;16m [38;5;94;48;5;230m░[38;5;221;48;5;230m░[38;5;52;48;5;16m [38;5;221;48;5;223m░[38;5;16;48;5;16m▓[38;5;52;48;5;16m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;136;48;5;220m [38;5;16;48;5;16m▓[38;5;220;48;5;221m [38;5;16;48;5;16m▓[38;5;226;48;5;226m [38;5;185;48;5;58m▒[38;5;229;48;5;229m [38;5;16;48;5;16m▓[38;5;229;48;5;229m [38;5;229;48;5;229m [38;5;16;48;5;16m▓[38;5;220;48;5;229m [38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;99;48;5;248m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;178;48;5;220m░[38;5;226;48;5;226m [38;5;226;48;5;226m [38;5;221;48;5;222m [38;5;17;48;5;233m [38;5;21;48;5;21m [38;5;17;48;5;232m [38;5;179;48;5;58m▒[38;5;136;48;5;222m [38;5;229;48;5;229m [38;5;230;48;5;231m [38;5;230;48;5;230m [38;5;52;48;5;16m [38;5;16;48;5;16m▓[38;5;69;48;5;21m [38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;221;48;5;214m [38;5;221;48;5;214m [38;5;222;48;5;221m [38;5;197;48;5;204m░[38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;1m░[38;5;197;48;5;204m [38;5;210;48;5;210m [38;5;211;48;5;198m [38;5;226;48;5;226m [38;5;16;48;5;16m▓[38;5;211;48;5;204m [38;5;210;48;5;210m [38;5;16;48;5;16m▓[38;5;60;48;5;248m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;221;48;5;220m [38;5;52;48;5;232m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;211;48;5;203m [38;5;204;48;5;1m░[38;5;197;48;5;168m░[38;5;204;48;5;210m [38;5;204;48;5;203m [38;5;172;48;5;180m░[38;5;209;48;5;131m▒[38;5;16;48;5;16m▓[38;5;197;48;5;198m [38;5;204;48;5;203m░[38;5;248;48;5;247m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;136;48;5;220m [38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;229;48;5;229m [38;5;16;48;5;16m▓[38;5;211;48;5;204m [38;5;201;48;5;201m [38;5;201;48;5;201m [38;5;52;48;5;16m [38;5;132;48;5;251m▓[38;5;84;48;5;251m▓[38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;228;48;5;228m [38;5;94;48;5;221m [38;5;221;48;5;214m [38;5;221;48;5;220m [38;5;16;48;5;16m▓[38;5;168;48;5;168m░[38;5;168;48;5;168m░[38;5;32;48;5;241m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;52;48;5;232m [38;5;84;48;5;253m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;227;48;5;227m [38;5;211;48;5;204m░[38;5;210;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;204m [38;5;16;48;5;16m▓[38;5;66;48;5;251m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;7;48;5;7m▓[38;5;16;48;5;16m▓[38;5;197;48;5;204m [38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;204;48;5;210m [38;5;52;48;5;232m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;210;48;5;210m [38;5;204;48;5;210m [38;5;211;48;5;204m░[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;197;48;5;204m░[38;5;204;48;5;210m [38;5;204;48;5;203m░[38;5;131;48;5;237m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;210;48;5;210m [38;5;16;48;5;16m▓[38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;210;48;5;210m [38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;101;48;5;238m▓[38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;210;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;169;48;5;238m▓[38;5;210;48;5;210m [38;5;210;48;5;210m [38;5;210;48;5;210m [38;5;16;48;5;16m▓[38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;210;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;210;48;5;210m [38;5;16;48;5;16m▓[38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;204;48;5;95m▒[38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;204;48;5;210m [38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;125;48;5;248m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [0m
        """;
    }
}