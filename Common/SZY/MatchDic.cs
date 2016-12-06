﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RuRo.Common
{
    public class MatchDic
    {
        private Dictionary<string, string> empiInfoDic { get; set; }
        private Dictionary<string, string> normalLisReportDic { get; set; }
        private Dictionary<string, string> patientDiagnoseDic { get; set; }
        private Dictionary<string, string> needNormalLisItems { get; set; }
        private Dictionary<string, string> needNormalLisReport { get; set; }

        public static Dictionary<string, string> EmpiInfoDic = new Dictionary<string, string>() {
            { "PatientName", "姓名" },
            { "Sex", "性别" },
            { "Birthday", "出生日期" },
            { "CardId", "身份证号" }
        };
        public static Dictionary<string, string> NormalLisReportDic = new Dictionary<string, string>() {
            //{ "hospnum", "Sample Source" },
            { "patname", "姓名" },
            { "Sex", "性别" },
            { "Age", "年龄" },
            { "age_month", "月" },
            { "ext_mthd", "项目总称" },
            { "chinese", "项目名称" },
            { "result", "结果" },
            { "units", "单位" },
            { "ref_flag", "高低" },
            { "lowvalue", "正常低值" },
            { "highvalue", "正常高值" },
            { "print_ref", "正常范围" },
            { "check_date", "批准时间" },
            { "check_by_name", "批准人" },
            { "prnt_order", "打印顺序序号" }
        };
        public static Dictionary<string, string> PatientDiagnoseDic = new Dictionary<string, string>() {
            { "PatientName", "姓名" },
            { "Sex", "性别" },
            { "Brithday", "出生日期" },
            { "CardId", "身份证号" },
            { "Icd", "ICD码" },
            { "Diagnose", "诊断名称" },
            { "Type", "诊断类型" },
            { "Flag", "诊断类别" },
            { "DiagnoseDate", "诊断日期" }
        };
        public static Dictionary<string, string> NeedRecordDic = new Dictionary<string, string>() {
             //{ "chinese","ext_mthd" },
             { "甲胎蛋白(AFP)定量","AFP定量" },
             { "糖链抗原19-9(CA19-9)","CA19-9" },
             { "糖链抗原242(CA242)","CA242" },
             { "癌胚抗原(CEA)定量","CEA定量" },
             { "D二聚体(D-Dimer)","D二聚体" },
             { "超敏肌钙蛋白I(TnI-Ultra)","TnI-Ultra" },
             { "粪便性状","粪便常规+潜血" },
             { "潜血试验","粪便常规+潜血" },
             { "阿米巴原虫(粪便)","粪便常规+潜血" },
             { "粪便颜色","粪便常规+潜血" },
             { "粪便红细胞","粪便常规+潜血" },
             { "粪便白细胞","粪便常规+潜血" },
             { "粪便寄生虫卵","粪便常规+潜血" },
             { "粪便粘液","粪便常规+潜血" },
             { "总胆红素(TBIL)","肝功12项" },
             { "白蛋白(ALB)","肝功12项" },
             { "直接胆红素(DBIL)","肝功12项" },
             { "谷草酶/谷丙酶(AST/ALT)","肝功12项" },
             { "腺苷脱氨酶(ADA)","肝功12项" },
             { "亮氨酸氨基肽酶(LAP)","肝功12项" },
             { "谷草转氨酶(AST)","肝功12项" },
             { "总胆汁酸(TBA)","肝功12项" },
             { "ALB/GLB","肝功12项" },
             { "谷丙转氨酶(ALT)","肝功12项" },
             { "γ-谷氨酰基转移酶（GGT)","肝功12项" },
             { "总蛋白(TP)","肝功12项" },
             { "球蛋白(GLB)","肝功12项" },
             { "前白蛋白(PA)","肝功12项" },
             { "碱性磷酸酶(ALP)","肝功12项" },
             { "间接胆红素(IBIL)","肝功12项" },
             { "尿素(Urea)","急诊生化(急,干)" },
             { "氯离子(Cl-)","急诊生化(急,干)" },
             { "葡萄糖(Glu)","急诊生化(急,干)" },
             { "钠离子(Na+)","急诊生化(急,干)" },
             { "肾小球滤过率估算值(eGFR)","急诊生化(急,干)" },
             { "总二氧化碳(TCO2)","急诊生化(急,干)" },
             { "肌酐(Cr)","急诊生化(急,干)" },
             { "钾离子(K+)","急诊生化(急,干)" },
             { "尿胆红素(干化学)","尿液分析+沉渣定量" },
             { "尿亚硝酸盐(干化学)","尿液分析+沉渣定量" },
             { "小圆上皮细胞[镜检]","尿液分析+沉渣定量" },
             { "尿液颜色","尿液分析+沉渣定量" },
             { "尿葡萄糖(干化学)","尿液分析+沉渣定量" },
             { "尿潜血(干化学)","尿液分析+沉渣定量" },
             { "尿病理管型计数","尿液分析+沉渣定量" },
             { "尿比重(干化学)","尿液分析+沉渣定量" },
             { "尿胆原(干化学)","尿液分析+沉渣定量" },
             { "上皮细胞[镜检]","尿液分析+沉渣定量" },
             { "真菌[镜检]","尿液分析+沉渣定量" },
             { "尿透明度","尿液分析+沉渣定量" },
             { "尿蛋白质(干化学)","尿液分析+沉渣定量" },
             { "尿红细胞计数","尿液分析+沉渣定量" },
             { "尿酮体(干化学)","尿液分析+沉渣定量" },
             { "尿白细胞计数","尿液分析+沉渣定量" },
             { "尿透明管型计数","尿液分析+沉渣定量" },
             { "结晶[镜检]","尿液分析+沉渣定量" },
             { "尿酸碱度(干化学)","尿液分析+沉渣定量" },
             { "尿白细胞酯酶(干化学)","尿液分析+沉渣定量" },
             { "纤维蛋白原(FIB)","凝血4项" },
             { "凝血酶时间(TT)","凝血4项" },
             { "活化部分凝血活酶时间(APTT)","凝血4项" },
             { "凝血酶原国际标准化比值(INR)","凝血4项" },
             { "凝血酶原时间(PT)","凝血4项" },
             { "凝血酶原活动度(AT)","凝血4项" },
             { "血红蛋白测定(Hb)","全血分析(五分类)" },
             { "平均红细胞Hb量(MCH)","全血分析(五分类)" },
             { "单核细胞计数(MONO)","全血分析(五分类)" },
             { "红细胞计数(RBC)","全血分析(五分类)" },
             { "中性粒细胞计数(NEUT)","全血分析(五分类)" },
             { "血小板体积分布宽度(PDW)","全血分析(五分类)" },
             { "白细胞计数(WBC)","全血分析(五分类)" },
             { "红细胞比积测定(HCT)","全血分析(五分类)" },
             { "血小板计数(PLT)","全血分析(五分类)" },
             { "嗜碱性粒细胞百分比(BASO%)","全血分析(五分类)" },
             { "红细胞体积分布宽度(RDW)","全血分析(五分类)" },
             { "平均血小板体积(MPV)","全血分析(五分类)" },
             { "单核细胞百分比(MONO%)","全血分析(五分类)" },
             { "平均红细胞体积(MCV)","全血分析(五分类)" },
             { "嗜酸性粒细胞百分比(EOSIN%)","全血分析(五分类)" },
             { "血小板压积(PCT)","全血分析(五分类)" },
             { "中性粒细胞百分比(NEUT%)","全血分析(五分类)" },
             { "嗜碱性粒细胞计数(BASO)","全血分析(五分类)" },
             { "嗜酸性粒细胞计数(EOSIN计数)","全血分析(五分类)" },
             { "平均红细胞Hb浓度(MCHC)","全血分析(五分类)" },
             { "淋巴细胞百分比(LYM%)","全血分析(五分类)" },
             { "淋巴细胞计数(LYM)","全血分析(五分类)" },
             { "HIV抗原抗体检测","输血4项" },
             { "甲苯胺红不加热血清试验(TRUST)","输血4项" },
             { "丙肝抗体定量检测","输血4项" },
             { "乙肝表面抗原定量","输血4项" },
             { "乳酸脱氢酶 (LDH)","心酶4项(急,干)" },
             { "肌酸激酶同工酶(CKMB)","心酶4项(急,干)" },
             { "肌酸激酶(CK)","心酶4项(急,干)" },
             { "血淀粉酶(AMY)","血淀粉酶(急,干)" },
             { "ABO血型正反定型(微柱法)","血型检测(微柱法)" },
             { "RhD血型(微柱法)","血型检测(微柱法)" }
        };

    }

    public class XmlToDic
    {
        public static void XMLToDic(string xPath, string filePath)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            XmlDocument xd = XmlHelper.XMLLoad(filePath);
            if (xd != null)
            {
                XmlNode xn = xd.SelectSingleNode(xPath);
                if (xn!=null)
                {
                    string str = JsonConvert.SerializeXmlNode(xn, Newtonsoft.Json.Formatting.None, true);
                }
            }
        }
    }
}
