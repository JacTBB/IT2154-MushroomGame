﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MushroomServer.Models.Characters
{
    public class Bowser : Character
    {
        public Bowser(int hp, int exp) : base("Bowser", hp, exp, "Fire Breath") { }

        public static string Art = """
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;167;48;5;166m░[38;5;209;48;5;202m [38;5;1;48;5;1m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;230;48;5;231m [38;5;178;48;5;229m [38;5;137;48;5;180m▒[38;5;225;48;5;231m [38;5;209;48;5;196m [38;5;160;48;5;160m [38;5;124;48;5;124m [38;5;209;48;5;196m [38;5;124;48;5;124m [38;5;88;48;5;88m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;179;48;5;94m░[38;5;172;48;5;58m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;94;48;5;235m░[38;5;94;48;5;242m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;204;48;5;138m▓[38;5;203;48;5;203m░[38;5;130;48;5;223m [38;5;112;48;5;58m [38;5;76;48;5;64m░[38;5;76;48;5;70m░[38;5;178;48;5;235m [38;5;209;48;5;196m░[38;5;209;48;5;202m░[38;5;88;48;5;88m [38;5;150;48;5;64m▒[38;5;29;48;5;237m▓[38;5;179;48;5;187m▒[38;5;178;48;5;229m [38;5;94;48;5;223m [38;5;106;48;5;58m [38;5;52;48;5;52m [38;5;52;48;5;52m [38;5;220;48;5;229m [38;5;94;48;5;95m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;131;48;5;138m▒[38;5;1;48;5;1m [38;5;209;48;5;202m [38;5;124;48;5;124m [38;5;191;48;5;64m░[38;5;209;48;5;202m [38;5;124;48;5;124m [38;5;52;48;5;52m [38;5;231;48;5;231m▓[38;5;70;48;5;64m░[38;5;82;48;5;70m [38;5;22;48;5;232m [38;5;84;48;5;238m▓[38;5;220;48;5;233m [38;5;192;48;5;64m░[38;5;156;48;5;70m [38;5;70;48;5;64m [38;5;185;48;5;3m░[38;5;1;48;5;1m [38;5;208;48;5;234m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;106;48;5;144m▓[38;5;230;48;5;231m [38;5;136;48;5;229m [38;5;136;48;5;229m [38;5;178;48;5;229m [38;5;178;48;5;229m [38;5;230;48;5;230m [38;5;230;48;5;230m [38;5;192;48;5;64m░[38;5;214;48;5;58m [38;5;94;48;5;58m [38;5;94;48;5;58m [38;5;94;48;5;187m▒[38;5;60;48;5;255m▓[38;5;162;48;5;255m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;76;48;5;22m [38;5;76;48;5;64m [38;5;156;48;5;70m [38;5;52;48;5;52m [38;5;1;48;5;1m [38;5;94;48;5;223m [38;5;179;48;5;58m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;214;48;5;222m [38;5;136;48;5;229m [38;5;220;48;5;229m [38;5;136;48;5;223m [38;5;136;48;5;229m [38;5;136;48;5;229m [38;5;172;48;5;180m▒[38;5;136;48;5;229m [38;5;221;48;5;223m [38;5;178;48;5;229m [38;5;172;48;5;179m▒[38;5;136;48;5;223m [38;5;136;48;5;229m [38;5;178;48;5;229m [38;5;222;48;5;94m [38;5;220;48;5;220m [38;5;184;48;5;184m░[38;5;150;48;5;236m▒[38;5;76;48;5;239m▒[38;5;56;48;5;255m [38;5;64;48;5;229m [38;5;82;48;5;70m [38;5;106;48;5;64m [38;5;202;48;5;137m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;172;48;5;58m [38;5;172;48;5;58m [38;5;130;48;5;58m [38;5;124;48;5;124m [38;5;1;48;5;1m [38;5;166;48;5;52m [38;5;130;48;5;58m [38;5;130;48;5;58m [38;5;172;48;5;58m [38;5;172;48;5;180m▒[38;5;136;48;5;229m [38;5;130;48;5;52m [38;5;222;48;5;215m [38;5;220;48;5;178m░[38;5;82;48;5;237m▓[38;5;70;48;5;7m▓[38;5;101;48;5;236m▓[38;5;209;48;5;232m [38;5;220;48;5;220m░[38;5;112;48;5;240m▓[38;5;230;48;5;231m [38;5;82;48;5;70m [38;5;76;48;5;64m [38;5;214;48;5;235m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;130;48;5;249m▓[38;5;221;48;5;58m░[38;5;215;48;5;58m [38;5;209;48;5;88m [38;5;124;48;5;124m [38;5;124;48;5;124m [38;5;209;48;5;88m░[38;5;94;48;5;58m [38;5;215;48;5;58m [38;5;221;48;5;223m [38;5;166;48;5;234m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;136;48;5;214m░[38;5;220;48;5;233m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;185;48;5;184m░[38;5;76;48;5;255m▓[38;5;82;48;5;22m [38;5;76;48;5;70m [38;5;112;48;5;58m [38;5;130;48;5;236m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;220;48;5;187m▓[38;5;172;48;5;58m░[38;5;220;48;5;142m▒[38;5;162;48;5;234m▓[38;5;84;48;5;241m▓[38;5;96;48;5;235m▓[38;5;130;48;5;233m [38;5;178;48;5;229m [38;5;178;48;5;229m [38;5;220;48;5;229m [38;5;221;48;5;223m [38;5;136;48;5;229m [38;5;136;48;5;229m [38;5;178;48;5;229m [38;5;172;48;5;101m▓[38;5;221;48;5;223m [38;5;94;48;5;223m [38;5;179;48;5;179m░[38;5;220;48;5;143m▒[38;5;136;48;5;144m▓[38;5;178;48;5;3m▒[38;5;57;48;5;236m▓[38;5;60;48;5;238m▓[38;5;76;48;5;234m▓[38;5;172;48;5;58m░[38;5;155;48;5;22m [38;5;231;48;5;231m▓[38;5;76;48;5;64m [38;5;76;48;5;22m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;130;48;5;234m [38;5;179;48;5;94m▒[38;5;220;48;5;220m [38;5;172;48;5;130m [38;5;220;48;5;220m [38;5;220;48;5;221m [38;5;163;48;5;234m▓[38;5;101;48;5;238m▓[38;5;178;48;5;221m░[38;5;172;48;5;143m▒[38;5;136;48;5;229m [38;5;178;48;5;229m [38;5;221;48;5;229m [38;5;172;48;5;101m▒[38;5;136;48;5;229m [38;5;220;48;5;229m [38;5;136;48;5;229m [38;5;136;48;5;229m [38;5;220;48;5;229m [38;5;172;48;5;223m░[38;5;220;48;5;221m [38;5;172;48;5;58m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m░[38;5;179;48;5;233m▒[38;5;60;48;5;252m▓[38;5;231;48;5;231m▓[38;5;156;48;5;22m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;230;48;5;230m [38;5;230;48;5;231m [38;5;221;48;5;58m [38;5;221;48;5;94m [38;5;178;48;5;220m░[38;5;221;48;5;243m▓[38;5;222;48;5;16m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;172;48;5;58m [38;5;179;48;5;94m▒[38;5;179;48;5;94m▒[38;5;220;48;5;229m [38;5;179;48;5;101m▒[38;5;179;48;5;94m▒[38;5;179;48;5;94m▒[38;5;172;48;5;94m▒[38;5;179;48;5;255m▓[38;5;221;48;5;229m░[38;5;214;48;5;58m [38;5;221;48;5;58m [38;5;214;48;5;136m░[38;5;222;48;5;58m [38;5;214;48;5;95m▒[38;5;220;48;5;185m▒[38;5;130;48;5;255m▒[38;5;231;48;5;231m▓[38;5;107;48;5;144m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;178;48;5;239m▓[38;5;230;48;5;230m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;221;48;5;94m [38;5;220;48;5;220m [38;5;166;48;5;52m [38;5;222;48;5;223m [38;5;222;48;5;223m [38;5;214;48;5;223m [38;5;214;48;5;223m [38;5;94;48;5;223m [38;5;172;48;5;222m░[38;5;172;48;5;137m▒[38;5;179;48;5;94m▒[38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;178;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;229;48;5;229m [38;5;231;48;5;231m▓[38;5;221;48;5;230m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;221;48;5;94m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;130;48;5;52m [38;5;172;48;5;94m▒[38;5;172;48;5;94m▒[38;5;172;48;5;94m▒[38;5;172;48;5;94m▒[38;5;172;48;5;94m▒[38;5;178;48;5;229m [38;5;229;48;5;229m [38;5;136;48;5;136m [38;5;220;48;5;220m [38;5;178;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;221;48;5;136m░[38;5;221;48;5;58m [38;5;220;48;5;58m [38;5;220;48;5;229m [38;5;172;48;5;239m▒[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;230;48;5;231m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;172;48;5;94m [38;5;166;48;5;52m [38;5;178;48;5;229m [38;5;178;48;5;229m [38;5;136;48;5;229m [38;5;136;48;5;229m [38;5;221;48;5;223m [38;5;136;48;5;229m [38;5;94;48;5;94m░[38;5;220;48;5;58m [38;5;221;48;5;136m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;221;48;5;136m░[38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;221;48;5;136m [38;5;220;48;5;3m▒[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;220;48;5;144m▓[38;5;179;48;5;224m░[38;5;231;48;5;231m▓[38;5;172;48;5;144m▓[38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;220;48;5;220m [38;5;230;48;5;231m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;220;48;5;236m▒[38;5;231;48;5;231m▓[38;5;94;48;5;95m▓[38;5;220;48;5;220m [38;5;221;48;5;241m▓[38;5;231;48;5;231m▓[38;5;220;48;5;220m [38;5;172;48;5;144m▓[38;5;230;48;5;231m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [0m
        """;
    }
}