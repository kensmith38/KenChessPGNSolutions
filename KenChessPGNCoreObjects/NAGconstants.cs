using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public static class NAGconstants
    {
        // $0           provided for the convenience of software designers as a placeholder value;
        //              should not appear in PGN files and has no typographic representation
        // $1-$9        Move Assessments
        // $10-$135     Positional Assessments
        // $136-$139    Time Pressure Commentaries
        // $140+        Not defined
        // Reference: https://en.wikipedia.org/wiki/Numeric_Annotation_Glyphs#Standard_NAGs
        // Ken chose to use symbols instead of text for traditional anlaysis (ex: "!" instead of "good move")
        public static string[] nagTable = {
            "",   // $0
            "!",  // $1 good move (traditional "!") 
            "?",  // $2 poor move or mistake (traditional "?")
            "!!", // $3 very good or brilliant move (traditional "!!") 
            "??", // $4 very poor move or blunder (traditional "??")
            "!?", // $5 speculative or interesting move (traditional "!?")
            "?!", // $6 questionable or dubious move (traditional "?!")
            "forced move (all others lose quickly) or only move", // $7
            "singular move (no reasonable alternatives)",// $8
            "worst move", // $9
            "=", // $10 drawish position or even
            "equal chances, quiet position", // $11
            "equal chances, active position", // $12
            "unclear position", // $13
            "White has a slight advantage", // $14
            "Black has a slight advantage", // $15
            "White has a moderate advantage", // $16
            "Black has a moderate advantage", // $17
            "+-", // $18 White has a decisive advantage
            "-+", // $19 Black has a decisive advantage
            "White has a crushing advantage (Black should resign)", // $20
            "Black has a crushing advantage (White should resign)", // $21
            "White is in zugzwang", // $22
            "Black is in zugzwang", // $23
            "White has a slight space advantage", // $24
            "Black has a slight space advantage", // $25
            "White has a moderate space advantage", // $26
            "Black has a moderate space advantage", // $27
            "White has a decisive space advantage", // $28
            "Black has a decisive space advantage", // $29
            "TBD", // $30
            "TBD", // $31
            "TBD", // $32
            "TBD", // $33
            "TBD", // $34
            "TBD", // $35
            "White has the initiative", // $36
            "Black has the initiative", // $37
            "TBD", // $38
            "TBD", // $39
            "TBD", // $40
            "TBD", // $41
            "TBD", // $42
            "TBD", // $43
            "TBD", // $44
            "TBD", // $45
            "TBD", // $46
            "TBD", // $47
            "TBD", // $48
            "TBD", // $49
            "TBD", // $50
            "TBD", // $51
            "TBD", // $52
            "TBD", // $53
            "TBD", // $54
            "TBD", // $55
            "TBD", // $56
            "TBD", // $57
            "TBD", // $58
            "TBD", // $59
            "TBD", // $60
            "TBD", // $61
            "TBD", // $62
            "TBD", // $63
            "TBD", // $64
            "TBD", // $65
            "TBD", // $66
            "TBD", // $67
            "TBD", // $68
            "TBD", // $69
            "TBD", // $70
            "TBD", // $71
            "TBD", // $72
            "TBD", // $73
            "TBD", // $74
            "TBD", // $75
            "TBD", // $76
            "TBD", // $77
            "TBD", // $78
            "TBD", // $79
            "TBD", // $80
            "TBD", // $81
            "TBD", // $82
            "TBD", // $83
            "TBD", // $84
            "TBD", // $85
            "TBD", // $86
            "TBD", // $87
            "TBD", // $88
            "TBD", // $89
            "TBD", // $90
            "TBD", // $91
            "TBD", // $92
            "TBD", // $93
            "TBD", // $94
            "TBD", // $95
            "TBD", // $96
            "TBD", // $97
            "TBD", // $98
            "TBD", // $99
            "TBD", // $100
            "TBD", // $101
            "TBD", // $102
            "TBD", // $103
            "TBD", // $104
            "TBD", // $105
            "TBD", // $106
            "TBD", // $107
            "TBD", // $108
            "TBD", // $109
            "TBD", // $110
            "TBD", // $111
            "TBD", // $112
            "TBD", // $113
            "TBD", // $114
            "TBD", // $115
            "TBD", // $116
            "TBD", // $117
            "TBD", // $118
            "TBD", // $119
            "TBD", // $120
            "TBD", // $121
            "TBD", // $122
            "TBD", // $123
            "TBD", // $124
            "TBD", // $125
            "TBD", // $126
            "TBD", // $127
            "TBD", // $128
            "TBD", // $129
            "TBD", // $130
            "TBD", // $131
            "TBD", // $132
            "TBD", // $133
            "TBD", // $134
            "TBD", // $135
            "White has moderate time control pressure", // $136
            "Black has moderate time control pressure", // $137
            "White has severe time control pressure", // $138
            "Black has severe time control pressure" // $139
        };
    }
}
