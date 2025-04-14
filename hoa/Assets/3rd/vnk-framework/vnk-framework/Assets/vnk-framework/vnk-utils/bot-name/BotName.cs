using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class BotName
    {
        static string[] botName = { "SwiftSlider", "Vicki D.Gilstrap", "James", "Barnaclue", "Kimberly", "Dorothy", "Annie", "William", "Trinidad", "Jeffrey R",
    "Tammy","Moses","Georgianna","Goodrich","Roger","Yow","John","Alvarez","Kathy","Benitez",
    "Kenneth","Sklar","Charles","CrashZombie","Gerri","August","Charles","Brewster","Bradyn Dreambringer","Ann A",
    "LiquidNecromancer","Stephen","Juan","Eddie","ColdLion","Stevie","Joe M. Lowry","Gayla","Guadalupe","Roseflaw",
    "Jose","Chandler","Branden","Shirley","Michael","Thompson","Wilbert","Matthew","Donald","Julie",
    "Frances","Cathy","Margery","IdenticalOctopus","Nicole","InfamousCoyote","Nancy","Nolen","Nora","Todd",
    "Primmer","Peter","Grayson","Roberta","Henderson","Jackie","Godfrey","Lori","HollowSeer","Embersnout",
    "Phoenixswift","Emmalynn","Battletrap","Martin","Waters","Ridley","Dane","Jessica","Silva","Jimmy",
    "Lee","Lois","Bedwell","Carina","Dunavant","Anthony","Sain","Pam","Shirley","Robinson",
    "Francis","Rosario","Trumb","Jerry","Cahoon","Ruth","Garcia","John","Kinlaw","Axeblood",
    "Daniel","Stjohn","Brittany","Solorzano","Eunice","Logan","Lowell","Sager","Terry","Lawrence",
        "Edward","P. Hagerman","Alma","Haywood","Kristopher","Wilkinson","Earleen","Lewis","Mark","Rangel",
        "Salvatore","Barnes","Russell","Wadsworth","Haynes","Angie","Rosenberry","John","Richard","L. Duffy",
        "Patricia","Watson","Lyle","Jonathan","Brent","Waller","Julius","Harris","Allen","Hartwell",
        "Teresa","Ricketts","Nancy","Jane","Compton","Lonnie","Greenfield","Casey","Whitesteam","Patricia",
        "McArthur","Lawrence","Anabel","Penning","Spidershard","Tillie","Gill","Shapiro","Morrison","DigitalCrocodile",
//VN
		"Phạm Hưng","Phan Thị Quỳnh","Đặng Thị Phương Lên","Hải Thao","Đỗ Trọng Tứ","Xuân Lan","Thu Quyên","Trương Thị Ánh","Kim Tưởng","Cẩm Tăng",
        "Lượng","Bạch Trà","Túy Đông","Thi Trực","Xuân Lương","Bá Đấu","Như Công","Huỳnh Nguyệt","Ngọc Lam","Đăng Kinh",
        "Nilly","Argos","Chinook","Faroon","Jigsaw","Darrius","Smirnoff","Mark","Humbug","Stripe",
        "Trường Minh","Cục Shit","Tao là nhất","Bố của bạn","Siêu nhân","Bá Đạo","Đạo sỹ thối","Ngọc Cáo","Ngọc ăn kứt","Đạt 09",
    "Quạt điện thống nhất","Máy","Bút máy","Cafe Sữa","Đậu Xanh","Em Thanh Hóa","Hoa Thanh Quế","Tôi là Tôi","Garen","Giường",
    "Mr.D","Ồ Shit","Bá Cháy","Bánh Trung Thu","Bạn của Bố","Nước Sting","Ăn Mỳ","Hảo Hảo","Chua","Bọ Xít",
    "Máy Đánh Mỡ","Bú","Alo Cái bô","Tôi","Kính mắt thời trang","Code","Anh Hùng","Xuân Ngọc","Đạt 1 lít","Nước Mắm",
    "Cá kho tàu","Chinsu","Tỏi","Beat","Hóng biến","Gái này","Tôi là Gay","Thái Lọ","Kim Cương","Vô đối",
    "Sát thủ","Đầu to","Bố cháu","Sơn Tùng MTP","Tùng Núi","Hoài Linh","MTP","Ca Sỹ Tùng","Sky ơi","Skype",
    "Bố Sơn Tùng","Vozer","Tủ Lạnh","Máy Chém","Tùng Sơn","Tha Thu","Nước trái cây","Tùng MTP","Phẩy S","Nát",
    "Em bạn Phú","Đánh không","Ngộ không","asdfgh","Lệ Rơi","Ổi","Lệ Rơi Bún Chả","Ca sỹ Lệ Rơi","Tao chấp hết","Quỳ",
    "Hà Nội","Sài Gòn","Đà Nẵng","Bố Thanh Hóa","Nghệ An","Tao Chém","Ác Quỷ","Thần Mặt Trời","Ngọc Trinh","Công Vinh",
    "Gay","Tú Lan","Thái Hòa","Bòi Anh Tuấn","Hồ Ngọc Hè","Game Hay","Sát Thủ Bóng","Chó đánh tao","Chim sẻ","Hehe",
    "Thịt mỡ","Tết","Ăn kít bố","Chó","Mèo","Tóc Xoăn","Sư chủ trì","Love","Bố mày","Mẹ mày",
        "CSGT","Hình Sự Thôn","DCM","dCMM","Chém","Gió","Vú Em","FBI","Làm Sao","Tên Hay",
//TH
		"จิณวัฒน์ สุขทั่ว","กิตติโชติ ดลโสภณ","ทวีผล มณีวรรณ์","สุธุรีพร นรินยา","สุบุษบรรณ ขวัญทอง","ชาคริด ดิษฐ์สระ","จีรศักดิ์ แก้วเมืองน้อย","สุธวินันท์ ศรีสุวรรณชนะ","ทวนศักดิ์ กาสีชา","สุนบภวรรณ์",
        "ทวีพล ภูมินำ","รุ่งทิพ","สุประพิณ","เหลือผล","Ninjava","Monkeyno","Evillan","ทรงกต","ทัศนัย","ชาคฤต",
        "แก้วไทรกล่ำ","สุนวล","ตั้งอิ้ว","สุบุบผา","ชาญรอบรู้","จรงค์พันธ์","สิมมา","จรวย","เนียมคำ","ต้นรักษ์",
        "หาระทา","สุธัญญา","กำลังเลิศ","สุโบตั๋น","สุขโพธิ์","ชูพงศ์","เจริญวรชัย","สุธมลวรรณ","ใจทา","ชรินท์",
        "ศรีสุกอง","สุธีราภรณ์","เคนแสนโคตร","ทฤษดี","เต็มใจรัก","สุไขนภา","ศิริเต็มกุล","สุบุบผาสวรรค์","รักษาภิกษุ","ณัชชา",
        "พิทัศน์","การ","แก้วนารี","ญาณเกียรติ","อู่สุวรรณ","ดลเลาะ","รามแก้ว","จิติชัย","บุญเทพประทาน","ทรงเดช",
//Nga
		"Jana Biryukova","Alekseyeva","Vsevolod Kovalyov","Chariton Ozerov","Akulina Sokolova","Bozena Vasilieva","Modest Vavilov","Guzel Borodina","Nina Kazakova","Isabella Matveyeva",
        "Yesenia","Sukhorukova","Nestor Fyodorov","Ravil Denisov","George Uvarov","Yefimova","Bulgakov","Abramov","Zaytseva","Sazonova",
        "Mary Zaitseva","Gavrilov","Uspenskaya","Evdokim Fomin","Edward","Polyakov","Gavrilova","Belov","Putin","Greta Efremova",
        "Gavrilov","Kirillova","Murat Andreev","Lebedeva","Lavrova","Sazonova","Bogolyubova","Yuriev","Panina","Artyomova",
        "Gerasimov","Zuyev","Belousov","Tokareva","Golovanov","Yermolayev","Yegorov","Alekseeva","Bogdanov","Muravyova",
        "Uspensky","Blinova","Artemova","Degtyaryov","Panteleimon","Kulikova","Gorbunov","Tokaryev","Tokareva","Bobrova",
		//Japan
		"椎名 舞","南井 修","進 桐子","都丸 学","小竹 勝","寺平 康平","隈本 実","治田 拓海","竹谷 翔太","檀 紅子",
        "河辺 麗華","姉崎 愛子","三隅 清","蔵 克己","平野 颯太","高月 貞子","浅賀 義雄","土岐 大和","柳岡 陽子","高戸 真一",
        "恒成 健太","猪川 一樹","樽谷 昭夫","鷲尾 真美","津金 雄大","生越 愛","谷垣 陽子","溝口 蓮","神作 朋美","荘司 梅子",
        "永瀬 節子","蒲生 千代","糸原 瞳","竹腰 葵","前河 大翔","布留川 茂","有澤 太陽","諸星 和也","長谷部 正博","安座間 正男",
        "中井川 七海","斉木 美優","田尾 勝","垣花 海斗","萩 駿","嬉野 明美","北浦 克己","大村 七海","箱山 瞳","荒井 豊",
		//China
		"Jun Feng","Fai Chien","Wen Mao","Cong Hu","Fai Tu","Hui Sun","Qiong K'ung","Bao Mao","Bo He","Jia Li Tsao",
        "Zhi Hsia","Guo Kao","Wei Hsing","Shen Tung","Wan Yeh","Li Ch'iu","Donglu Niu","Tao Wu","Jie Yao","Jin Chia",
        "Kuan-Yin He","Yi Min Teng","Yuan Lü","Kuan-Yin Jen","Hsin Chung","Li Tang","Sheng Yang","Huan Peng","Qing Yuan P'an","Bo Niu",
        "Peng Wan","Xiong Tsai","Yan Liang","You Lin","Fai Lo","Guo He","Cheng Hsu","Feng K'ung","An Liang","Rong Su",
        "Sying Wu","Park Tseng","Sun He","Ying Chung","Li Hua Hu","Song Lu","Long He","Hui Kuo","Jun Chien","Feng Hê",
		//Italy
		"DeRose","Boni","Maurizio","Consuelo","Lombardo","Dolcelino","Russo","Rinaldo","Fallaci","Teresio",
        "Lucchese","Marta","Arcuri","Ricci","Ninfa","Pierino","Capon","Generoso","Panicucci","Ferruccio",
        "Giona","Napolitani","Fortunata","Costa","Cino","Rossi","Marilena","Cattaneo","Flaviano","Zito",
        "Daniela","De Luca","Nicodemo","Napolitani","Proserpina","Trentino","Oberto","Palerma","Matilde","Pirozzi",
		//Arabic

		"Areebah","Rumailah","Saja","Samar","Samira","Jameela","Murad","Saad","Fayha","Hafa",
        "Muzzammil","Fayyad","Awad","Yusri","Wahhab","Sarraf","Fadl","Allah","Sariyah","Tannous",
        "Taslim","Farooq","Haddad","Nazaaha","Shahlah","Baz","Abdul","Jarir","Botros","Nazari",
		//Úc
		"Matthew","Stonham","Charlotte","Macnamara","John","Petherick","Kaitlyn","McAdam","Adam","Leach",
        "Milla","Blakey","Gabrielle","Ernest","Edward","Menkens","Jaxon","Waddell","Justin","Khull",
        "Taylah","Fewings","Thomas","Mustar","Ella","Logue","Sophie","Ledger","Heap","Skye",

		//Brazin
		"João","Cardoso","Cavalcanti","Alice","Rocha","Azevedo","Sousa","Ribeiro","Emily","Gomes",
        "Oliveira","Gabrielly","Arthur","Cunha","Almeida","Rocha","Tiago","Goncalves","Carlos","Santos",
        "Pinto","Mateus","Cunha","Cavalcanti","Carolina","Santos","Martins","Igor","Rocha","Rodrigues",
        "Mariana","Carvalho","Rodrigues","Carla","Melo","Isabella","Souza","Oliveira","Gabrielly","Azevedo",
        "Erick","Cardoso","Eduardo","Oliveira","Ribeiro","Cunha","Fernanda","Santos","André","Gomes",
		//Dutch 
		"Estelle","Spa","Mack","Ganesh","John","van Hooren","Pleunie","Laagland","Antoni","Litsenburg",
        "Davy","Zoet","Beytullah","van Eijck","Konrad","Quist","Tan","Wendie","Adaja","Braakhekke",
        "Elwin","Zandvliet","Eldert","Louwen","Cassandra","Buis","Funda","van Vark","Nikolaj","Huinink",
		//Finish
		"Marko","Hull","Helkovaara","Ida","Parviainen","Kaari","Tapio","Itälä","Essi","Jokela",
        "Eveliina","Sihvonen","Tahvo","Hyytiä","Emilia","Pekkanen","Olavi","Noronen","Valentin","Lajunen",
        "Jyrki","Toivonen","Kaiju","Oksanen","Veli-Pekka","Leskinen","Arja","Hirvonen","Elias","Alho",
        "Virpi","Risku","Hanna","Repo","Kaiju","Seppinen","Sebastian","Madetoja","Keke","Inberg",
		//Pháp
		"Valiant","Quinn","Geneviève","Bordeaux","Javier","Soucy","Honoré","Mathieu","Pinabel","Charron",
        "Aymon","de Brisay","Garland","Lebel","Marc","Bizier","Renée","Mothé","Pierpont","de Chateaub",
        "Lundy","Coudert","Satordi","Voisine","Esperanza","Frappier","Noelle","Dagenais","Mariette","Bourget",

		//Đức
		"Birgit","Schultheiss","Jennifer","Foerster","Robert","Schroeder","Christian","Weissmuller","Thorsten","Tom",
        "Scholz","Marie","Peters","Sarah","Klein","Max","Rothstein","Marko","Köhler","Torsten",
        "Bumgarner","Simone","Kappel","Frank","Schmitt","Katja","Fruehauf","Ines","Schiffer","Antje Dietrich",

		//Hungary
		"Bognár","Marcell","Györffy","Malika","Takáts","Aggie","Radics","Liza","Smid","Anasztaizia",
        "Kultsár","Malika","Sinka","Boldizsar","Söröss","Evelin","Szölôs","Farkas","Vöröss","Dalma",
        "Rátz","Jucika","Kuntz","Odön","Gyôrffi","Ibolya","Jakab","Adrienn","Demeter","Fodor",
		//Polish
		"Wiga","Majewska","Czesława","Jaworska","Iwo","Maciejewski","Serafina","Symanska","Julitta","Kucharska",
        "Egidiusz","Chmielewski","Bazyli","Wysocki","Kazimiera","Pawlak","Aron","Duda","Bożena","Majewska",
    };

        public static string GetRandomBotName()
        {
            int id = UnityEngine.Random.Range(0, botName.Length);
            return botName[id];
        }
    }
}
