﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MushroomServer.Models.Characters
{
    public class Luigi : Character
    {
        public Luigi() : base("Luigi", 100, 0, "Precision and Accuracy") { }

        public static string Art = """
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;71;48;5;71m▒[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;16;48;5;16m▓[38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;166;48;5;94m░[38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;172;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;172;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;130;48;5;222m [38;5;16;48;5;16m▓[38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;16;48;5;16m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;222;48;5;222m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;78;48;5;71m▒[38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;78;48;5;71m▒[38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;78;48;5;71m▒[38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;78;48;5;71m▒[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;178;48;5;220m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;17;48;5;17m [38;5;178;48;5;220m [38;5;4;48;5;4m [38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;114;48;5;71m▒[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;4;48;5;4m [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;230;48;5;231m [38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;230;48;5;231m [38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;230;48;5;231m [38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;166;48;5;94m░[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[38;5;231;48;5;231m▓[0m
        [0m
        """;
    }
}
