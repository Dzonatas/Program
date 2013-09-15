/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Runtime.InteropServices ;
using System ;

namespace Snowglobe
	{
	public sealed partial class Agent
		{
		public class Animation
			{
			static public UUID Afraid                  = new UUID("6b61c8e8-4747-0d75-12d7-e49ff207a4ca") ;
			static public UUID AimBazookaR             = new UUID("b5b4a67d-0aee-30d2-72cd-77b333e932ef") ;
			static public UUID AimBowL                 = new UUID("46bb4359-de38-4ed8-6a22-f1f52fe8f506") ;
			static public UUID AimHandgunR             = new UUID("3147d815-6338-b932-f011-16b56d9ac18b") ;
			static public UUID AimRifleR               = new UUID("ea633413-8006-180a-c3ba-96dd1d756720") ;
			static public UUID Angry                   = new UUID("5747a48e-073e-c331-f6f3-7c2149613d3e") ;
			static public UUID Away                    = new UUID("fd037134-85d4-f241-72c6-4f42164fedee") ;
			static public UUID Backflip                = new UUID("c4ca6188-9127-4f31-0158-23c4e2f93304") ;
			static public UUID BellyLaugh              = new UUID("18b3a4b5-b463-bd48-e4b6-71eaac76c515") ;
			static public UUID BlowKiss                = new UUID("db84829b-462c-ee83-1e27-9bbee66bd624") ;
			static public UUID BodyNoise               = new UUID("9aa8b0a6-0c6f-9518-c7c3-4f41f2c001ad") ;
			static public UUID Bored                   = new UUID("b906c4ba-703b-1940-32a3-0c7f7d791510") ;
			static public UUID Bow                     = new UUID("82e99230-c906-1403-4d9c-3889dd98daba") ;
			static public UUID BreatheRot              = new UUID("4c5a103e-b830-2f1c-16bc-224aa0ad5bc8") ;
			static public UUID Brush                   = new UUID("349a3801-54f9-bf2c-3bd0-1ac89772af01") ;
			static public UUID Busy                    = new UUID("efcf670c-2d18-8128-973a-034ebc806b67") ;
			static public UUID Clap                    = new UUID("9b0c1c4e-8ac7-7969-1494-28c874c4f668") ;
			static public UUID Courtbow                = new UUID("9ba1c942-08be-e43a-fb29-16ad440efc50") ;
			static public UUID Crouch                  = new UUID("201f3fdf-cb1f-dbec-201f-7333e328ae7c") ;
			static public UUID Crouchwalk              = new UUID("47f5f6fb-22e5-ae44-f871-73aaaf4a6022") ;
			static public UUID Cry                     = new UUID("92624d3e-1068-f1aa-a5ec-8244585193ed") ;
			static public UUID Customize               = new UUID("038fcec9-5ebd-8a8e-0e2e-6e71a0a1ac53") ;
			static public UUID CustomizeDone           = new UUID("6883a61a-b27b-5914-a61e-dda118a9ee2c") ;
			static public UUID Dance1                  = new UUID("b68a3d7c-de9e-fc87-eec8-543d787e5b0d") ;
			static public UUID Dance2                  = new UUID("928cae18-e31d-76fd-9cc9-2f55160ff818") ;
			static public UUID Dance3                  = new UUID("30047778-10ea-1af7-6881-4db7a3a5a114") ;
			static public UUID Dance4                  = new UUID("951469f4-c7b2-c818-9dee-ad7eea8c30b7") ;
			static public UUID Dance5                  = new UUID("4bd69a1d-1114-a0b4-625f-84e0a5237155") ;
			static public UUID Dance6                  = new UUID("cd28b69b-9c95-bb78-3f94-8d605ff1bb12") ;
			static public UUID Dance7                  = new UUID("a54d8ee2-28bb-80a9-7f0c-7afbbe24a5d6") ;
			static public UUID Dance8                  = new UUID("b0dc417c-1f11-af36-2e80-7e7489fa7cdc") ;
			static public UUID Dead                    = new UUID("57abaae6-1d17-7b1b-5f98-6d11a6411276") ;
			static public UUID Drink                   = new UUID("0f86e355-dd31-a61c-fdb0-3a96b9aad05f") ;
			static public UUID Editing                 = new UUID("2a8eba1d-a7f8-5596-d44a-b4977bf8c8bb") ;
			static public UUID Embarrassed             = new UUID("514af488-9051-044a-b3fc-d4dbf76377c6") ;
			static public UUID ExpressAfraid           = new UUID("aa2df84d-cf8f-7218-527b-424a52de766e") ;
			static public UUID ExpressAnger            = new UUID("1a03b575-9634-b62a-5767-3a679e81f4de") ;
			static public UUID ExpressBored            = new UUID("214aa6c1-ba6a-4578-f27c-ce7688f61d0d") ;
			static public UUID ExpressCry              = new UUID("d535471b-85bf-3b4d-a542-93bea4f59d33") ;
			static public UUID ExpressDisdain          = new UUID("d4416ff1-09d3-300f-4183-1b68a19b9fc1") ;
			static public UUID ExpressEmbarrassed      = new UUID("0b8c8211-d78c-33e8-fa28-c51a9594e424") ;
			static public UUID ExpressFrown            = new UUID("fee3df48-fa3d-1015-1e26-a205810e3001") ;
			static public UUID ExpressKiss             = new UUID("1e8d90cc-a84e-e135-884c-7c82c8b03a14") ;
			static public UUID ExpressLaugh            = new UUID("62570842-0950-96f8-341c-809e65110823") ;
			static public UUID ExpressOpenMouth        = new UUID("d63bc1f9-fc81-9625-a0c6-007176d82eb7") ;
			static public UUID ExpressRepulsed         = new UUID("f76cda94-41d4-a229-2872-e0296e58afe1") ;
			static public UUID ExpressSad              = new UUID("eb6ebfb2-a4b3-a19c-d388-4dd5c03823f7") ;
			static public UUID ExpressShrug            = new UUID("a351b1bc-cc94-aac2-7bea-a7e6ebad15ef") ;
			static public UUID ExpressSmile            = new UUID("b7c7c833-e3d3-c4e3-9fc0-131237446312") ;
			static public UUID ExpressSurprise         = new UUID("728646d9-cc79-08b2-32d6-937f0a835c24") ;
			static public UUID ExpressTongueOut        = new UUID("835965c6-7f2f-bda2-5deb-2478737f91bf") ;
			static public UUID ExpressToothsmile       = new UUID("b92ec1a5-e7ce-a76b-2b05-bcdb9311417e") ;
			static public UUID ExpressWink             = new UUID("da020525-4d94-59d6-23d7-81fdebf33148") ;
			static public UUID ExpressWorry            = new UUID("9c05e5c7-6f07-6ca4-ed5a-b230390c3950") ;
			static public UUID Eye                     = new UUID("5c780ea8-1cd1-c463-a128-48c023f6fbea") ;
			static public UUID Falldown                = new UUID("666307d9-a860-572d-6fd4-c3ab8865c094") ;
			static public UUID FemaleWalk              = new UUID("f5fc7433-043d-e819-8298-f519a119b688") ;
			static public UUID FingerWag               = new UUID("c1bc7f36-3ba0-d844-f93c-93be945d644f") ;
			static public UUID FistPump                = new UUID("7db00ccd-f380-f3ee-439d-61968ec69c8a") ;
			static public UUID Fly                     = new UUID("aec4610c-757f-bc4e-c092-c6e9caf18daf") ;
			static public UUID FlyAdjust               = new UUID("db95561f-f1b0-9f9a-7224-b12f71af126e") ;
			static public UUID FlySlow                 = new UUID("2b5a38b2-5e00-3a97-a495-4c826bc443e6") ;
			static public UUID HandMotion              = new UUID("ce986325-0ba7-6e6e-cc24-b17c4b795578") ;
			static public UUID HeadRot                 = new UUID("e6e8d1dd-e643-fff7-b238-c6b4b056a68d") ;
			static public UUID Hello                   = new UUID("9b29cd61-c45b-5689-ded2-91756b8d76a9") ;
			static public UUID HoldBazookaR            = new UUID("ef62d355-c815-4816-2474-b1acc21094a6") ;
			static public UUID HoldBowL                = new UUID("8b102617-bcba-037b-86c1-b76219f90c88") ;
			static public UUID HoldHandgunR            = new UUID("efdc1727-8b8a-c800-4077-975fc27ee2f2") ;
			static public UUID HoldRifleR              = new UUID("3d94bad0-c55b-7dcc-8763-033c59405d33") ;
			static public UUID HoldThrowR              = new UUID("7570c7b5-1f22-56dd-56ef-a9168241bbb6") ;
			static public UUID Hover                   = new UUID("4ae8016b-31b9-03bb-c401-b1ea941db41d") ;
			static public UUID HoverDown               = new UUID("20f063ea-8306-2562-0b07-5c853b37b31e") ;
			static public UUID HoverUp                 = new UUID("62c5de58-cb33-5743-3d07-9e4cd4352864") ;
			static public UUID Impatient               = new UUID("5ea3991f-c293-392e-6860-91dfa01278a3") ;
			static public UUID Jump                    = new UUID("2305bd75-1ca9-b03b-1faa-b176b8a8c49e") ;
			static public UUID JumpForJoy              = new UUID("709ea28e-1573-c023-8bf8-520c8bc637fa") ;
			static public UUID KissMyButt              = new UUID("19999406-3a3a-d58c-a2ac-d72e555dcf51") ;
			static public UUID Land                    = new UUID("7a17b059-12b2-41b1-570a-186368b6aa6f") ;
			static public UUID LaughShort              = new UUID("ca5b3f14-3194-7a2b-c894-aa699b718d1f") ;
			static public UUID MediumLand              = new UUID("f4f00d6e-b9fe-9292-f4cb-0ae06ea58d57") ;
			static public UUID MotorcycleSit           = new UUID("08464f78-3a8e-2944-cba5-0c94aff3af29") ;
			static public UUID MuscleBeach             = new UUID("315c3a41-a5f3-0ba4-27da-f893f769e69b") ;
			static public UUID No                      = new UUID("5a977ed9-7f72-44e9-4c4c-6e913df8ae74") ;
			static public UUID NoUnhappy               = new UUID("d83fa0e5-97ed-7eb2-e798-7bd006215cb4") ;
			static public UUID NyahNyah                = new UUID("f061723d-0a18-754f-66ee-29a44795a32f") ;
			static public UUID OnetwoPunch             = new UUID("eefc79be-daae-a239-8c04-890f5d23654a") ;
			static public UUID Peace                   = new UUID("b312b10e-65ab-a0a4-8b3c-1326ea8e3ed9") ;
			static public UUID PelvisFix               = new UUID("0c5dd2a2-514d-8893-d44d-05beffad208b") ;
			static public UUID PointMe                 = new UUID("17c024cc-eef2-f6a0-3527-9869876d7752") ;
			static public UUID PointYou                = new UUID("ec952cca-61ef-aa3b-2789-4d1344f016de") ;
			static public UUID PreJump                 = new UUID("7a4e87fe-de39-6fcb-6223-024b00893244") ;
			static public UUID PunchLeft               = new UUID("f3300ad9-3462-1d07-2044-0fef80062da0") ;
			static public UUID PunchRight              = new UUID("c8e42d32-7310-6906-c903-cab5d4a34656") ;
			static public UUID Repulsed                = new UUID("36f81a92-f076-5893-dc4b-7c3795e487cf") ;
			static public UUID RoundhouseKick          = new UUID("49aea43b-5ac3-8a44-b595-96100af0beda") ;
			static public UUID RpsCountdown            = new UUID("35db4f7e-28c2-6679-cea9-3ee108f7fc7f") ;
			static public UUID RpsPaper                = new UUID("0836b67f-7f7b-f37b-c00a-460dc1521f5a") ;
			static public UUID RpsRock                 = new UUID("42dd95d5-0bc6-6392-f650-777304946c0f") ;
			static public UUID RpsScissors             = new UUID("16803a9f-5140-e042-4d7b-d28ba247c325") ;
			static public UUID Run                     = new UUID("05ddbff8-aaa9-92a1-2b74-8fe77a29b445") ;
			static public UUID Sad                     = new UUID("0eb702e2-cc5a-9a88-56a5-661a55c0676a") ;
			static public UUID Salute                  = new UUID("cd7668a6-7011-d7e2-ead8-fc69eff1a104") ;
			static public UUID ShootBowL               = new UUID("e04d450d-fdb5-0432-fd68-818aaf5935f8") ;
			static public UUID Shout                   = new UUID("6bd01860-4ebd-127a-bb3d-d1427e8e0c42") ;
			static public UUID Shrug                   = new UUID("70ea714f-3a97-d742-1b01-590a8fcd1db5") ;
			static public UUID Sit                     = new UUID("1a5fe8ac-a804-8a5d-7cbd-56bd83184568") ;
			static public UUID SitFemale               = new UUID("b1709c8d-ecd3-54a1-4f28-d55ac0840782") ;
			static public UUID SitGeneric              = new UUID("245f3c54-f1c0-bf2e-811f-46d8eeb386e7") ;
			static public UUID SitGround               = new UUID("1c7600d6-661f-b87b-efe2-d7421eb93c86") ;
			static public UUID SitGroundConstrained    = new UUID("1a2bd58e-87ff-0df8-0b4c-53e047b0bb6e") ;
			static public UUID SitToStand              = new UUID("a8dee56f-2eae-9e7a-05a2-6fb92b97e21e") ;
			static public UUID Sleep                   = new UUID("f2bed5f9-9d44-39af-b0cd-257b2a17fe40") ;
			static public UUID SmokeIdle               = new UUID("d2f2ee58-8ad1-06c9-d8d3-3827ba31567a") ;
			static public UUID SmokeInhale             = new UUID("6802d553-49da-0778-9f85-1599a2266526") ;
			static public UUID SmokeThrowDown          = new UUID("0a9fb970-8b44-9114-d3a9-bf69cfe804d6") ;
			static public UUID Snapshot                = new UUID("eae8905b-271a-99e2-4c0e-31106afd100c") ;
			static public UUID Stand                   = new UUID("2408fe9e-df1d-1d7d-f4ff-1384fa7b350f") ;
			static public UUID Standup                 = new UUID("3da1d753-028a-5446-24f3-9c9b856d9422") ;
			static public UUID Stand1                  = new UUID("15468e00-3400-bb66-cecc-646d7c14458e") ;
			static public UUID Stand2                  = new UUID("370f3a20-6ca6-9971-848c-9a01bc42ae3c") ;
			static public UUID Stand3                  = new UUID("42b46214-4b44-79ae-deb8-0df61424ff4b") ;
			static public UUID Stand4                  = new UUID("f22fed8b-a5ed-2c93-64d5-bdd8b93c889f") ;
			static public UUID Stretch                 = new UUID("80700431-74ec-a008-14f8-77575e73693f") ;
			static public UUID Stride                  = new UUID("1cb562b0-ba21-2202-efb3-30f82cdf9595") ;
			static public UUID Surf                    = new UUID("41426836-7437-7e89-025d-0aa4d10f1d69") ;
			static public UUID Surprise                = new UUID("313b9881-4302-73c0-c7d0-0e7a36b6c224") ;
			static public UUID SwordStrike             = new UUID("85428680-6bf9-3e64-b489-6f81087c24bd") ;
			static public UUID Talk                    = new UUID("5c682a95-6da4-a463-0bf6-0f5b7be129d1") ;
			static public UUID Tantrum                 = new UUID("11000694-3f41-adc2-606b-eee1d66f3724") ;
			static public UUID Target                  = new UUID("0e4896cb-fba4-926c-f355-8720189d5b55") ;
			static public UUID ThrowR                  = new UUID("aa134404-7dac-7aca-2cba-435f9db875ca") ;
			static public UUID TryOnShirt              = new UUID("83ff59fe-2346-f236-9009-4e3608af64c1") ;
			static public UUID TurnLeft                = new UUID("56e0ba0d-4a9f-7f27-6117-32f2ebbf6135") ;
			static public UUID TurnRight               = new UUID("2d6daa51-3192-6794-8e2e-a15f8338ec30") ;
			static public UUID Type                    = new UUID("c541c47f-e0c0-058b-ad1a-d6ae3a4584d9") ;
			static public UUID Walk                    = new UUID("6ed24bd8-91aa-4b12-ccc7-c97c857ab4e0") ;
			static public UUID WalkAdjust              = new UUID("829bc85b-02fc-ec41-be2e-74cc6dd7215d") ;
			static public UUID Whisper                 = new UUID("7693f268-06c7-ea71-fa21-2b30d6533f8f") ;
			static public UUID Whistle                 = new UUID("b1ed7982-c68e-a982-7561-52a88a5298c0") ;
			static public UUID Wink                    = new UUID("869ecdad-a44b-671e-3266-56aef2e3ac2e") ;
			static public UUID WinkHollywood           = new UUID("c0c4030f-c02b-49de-24ba-2331f43fe41c") ;
			static public UUID Worry                   = new UUID("9f496bd2-589a-709f-16cc-69bf7df1d36c") ;
			static public UUID Yes                     = new UUID("15dd911d-be82-2856-26db-27659b142875") ;
			static public UUID YesHappy                = new UUID("b8c8b2a3-9008-1771-3bfc-90924955ab2d") ;
			static public UUID YogaFloat               = new UUID("42ecd00b-9947-a97c-400a-bbc9174c7aeb") ;
	
	
			static object[,] list_raw = new object[,]
				{
					{ Afraid                 , "Afraid" },
					{ AimBazookaR            , "AimBazookaR" },
					{ AimBowL                , "AimBowL" },
					{ AimHandgunR            , "AimHandgunR" },
					{ AimRifleR              , "AimRifleR" },
					{ Angry                  , "Angry" },
					{ Away                   , "Away" },
					{ Backflip               , "Backflip" },
					{ BellyLaugh             , "BellyLaugh" },
					{ BlowKiss               , "BlowKiss" },
					{ BodyNoise              , "BodyNoise" },
					{ Bored                  , "Bored" },
					{ Bow                    , "Bow" },
					{ BreatheRot             , "BreatheRot" },
					{ Brush                  , "Brush" },
					{ Busy                   , "Busy" },
					{ Clap                   , "Clap" },
					{ Courtbow               , "Courtbow" },
					{ Crouch                 , "Crouch" },
					{ Crouchwalk             , "Crouchwalk" },
					{ Cry                    , "Cry" },
					{ Customize              , "Customize" },
					{ CustomizeDone          , "CustomizeDone" },
					{ Dance1                 , "Dance1" },
					{ Dance2                 , "Dance2" },
					{ Dance3                 , "Dance3" },
					{ Dance4                 , "Dance4" },
					{ Dance5                 , "Dance5" },
					{ Dance6                 , "Dance6" },
					{ Dance7                 , "Dance7" },
					{ Dance8                 , "Dance8" },
					{ Dead                   , "Dead" },
					{ Drink                  , "Drink" },
					{ Editing                , "Editing" },
					{ Embarrassed            , "Embarrassed" },
					{ ExpressAfraid          , "ExpressAfraid" },
					{ ExpressAnger           , "ExpressAnger" },
					{ ExpressBored           , "ExpressBored" },
					{ ExpressCry             , "ExpressCry" },
					{ ExpressDisdain         , "ExpressDisdain" },
					{ ExpressEmbarrassed     , "ExpressEmbarrassed" },
					{ ExpressFrown           , "ExpressFrown" },
					{ ExpressKiss            , "ExpressKiss" },
					{ ExpressLaugh           , "ExpressLaugh" },
					{ ExpressOpenMouth       , "ExpressOpenMouth" },
					{ ExpressRepulsed        , "ExpressRepulsed" },
					{ ExpressSad             , "ExpressSad" },
					{ ExpressShrug           , "ExpressShrug" },
					{ ExpressSmile           , "ExpressSmile" },
					{ ExpressSurprise        , "ExpressSurprise" },
					{ ExpressTongueOut       , "ExpressTongueOut" },
					{ ExpressToothsmile      , "ExpressToothsmile" },
					{ ExpressWink            , "ExpressWink" },
					{ ExpressWorry           , "ExpressWorry" },
					{ Eye                    , "Eye" },
					{ Falldown               , "Falldown" },
					{ FemaleWalk             , "FemaleWalk" },
					{ FingerWag              , "FingerWag" },
					{ FistPump               , "FistPump" },
					{ Fly                    , "Fly" },
					{ FlyAdjust              , "FlyAdjust" },
					{ FlySlow                , "FlySlow" },
					{ HandMotion             , "HandMotion" },
					{ HeadRot                , "HeadRot" },
					{ Hello                  , "Hello" },
					{ HoldBazookaR           , "HoldBazookaR" },
					{ HoldBowL               , "HoldBowL" },
					{ HoldHandgunR           , "HoldHandgunR" },
					{ HoldRifleR             , "HoldRifleR" },
					{ HoldThrowR             , "HoldThrowR" },
					{ Hover                  , "Hover" },
					{ HoverDown              , "HoverDown" },
					{ HoverUp                , "HoverUp" },
					{ Impatient              , "Impatient" },
					{ Jump                   , "Jump" },
					{ JumpForJoy             , "JumpForJoy" },
					{ KissMyButt             , "KissMyButt" },
					{ Land                   , "Land" },
					{ LaughShort             , "LaughShort" },
					{ MediumLand             , "MediumLand" },
					{ MotorcycleSit          , "MotorcycleSit" },
					{ MuscleBeach            , "MuscleBeach" },
					{ No                     , "No" },
					{ NoUnhappy              , "NoUnhappy" },
					{ NyahNyah               , "NyahNyah" },
					{ OnetwoPunch            , "OnetwoPunch" },
					{ Peace                  , "Peace" },
					{ PelvisFix              , "PelvisFix" },
					{ PointMe                , "PointMe" },
					{ PointYou               , "PointYou" },
					{ PreJump                , "PreJump" },
					{ PunchLeft              , "PunchLeft" },
					{ PunchRight             , "PunchRight" },
					{ Repulsed               , "Repulsed" },
					{ RoundhouseKick         , "RoundhouseKick" },
					{ RpsCountdown           , "RpsCountdown" },
					{ RpsPaper               , "RpsPaper" },
					{ RpsRock                , "RpsRock" },
					{ RpsScissors            , "RpsScissors" },
					{ Run                    , "Run" },
					{ Sad                    , "Sad" },
					{ Salute                 , "Salute" },
					{ ShootBowL              , "ShootBowL" },
					{ Shout                  , "Shout" },
					{ Shrug                  , "Shrug" },
					{ Sit                    , "Sit" },
					{ SitFemale              , "SitFemale" },
					{ SitGeneric             , "SitGeneric" },
					{ SitGround              , "SitGround" },
					{ SitGroundConstrained   , "SitGroundConstrained" },
					{ SitToStand             , "SitToStand" },
					{ Sleep                  , "Sleep" },
					{ SmokeIdle              , "SmokeIdle" },
					{ SmokeInhale            , "SmokeInhale" },
					{ SmokeThrowDown         , "SmokeThrowDown" },
					{ Snapshot               , "Snapshot" },
					{ Stand                  , "Stand" },
					{ Standup                , "Standup" },
					{ Stand1                 , "Stand1" },
					{ Stand2                 , "Stand2" },
					{ Stand3                 , "Stand3" },
					{ Stand4                 , "Stand4" },
					{ Stretch                , "Stretch" },
					{ Stride                 , "Stride" },
					{ Surf                   , "Surf" },
					{ Surprise               , "Surprise" },
					{ SwordStrike            , "SwordStrike" },
					{ Talk                   , "Talk" },
					{ Tantrum                , "Tantrum" },
					{ Target                 , "Target" },
					{ ThrowR                 , "ThrowR" },
					{ TryOnShirt             , "TryOnShirt" },
					{ TurnLeft               , "TurnLeft" },
					{ TurnRight              , "TurnRight" },
					{ Type                   , "Type" },
					{ Walk                   , "Walk" },
					{ WalkAdjust             , "WalkAdjust" },
					{ Whisper                , "Whisper" },
					{ Whistle                , "Whistle" },
					{ Wink                   , "Wink" },
					{ WinkHollywood          , "WinkHollywood" },
					{ Worry                  , "Worry" },
					{ Yes                    , "Yes" },
					{ YesHappy               , "YesHappy" },
					{ YogaFloat              , "YogaFloat" },
				};

			static public string Lookup( UUID id )
				{
				for( int x = 0 ; x < ( list_raw.Length / 2) ; x++ )
					{
					if( id == (UUID) list_raw[x,0] )
						return (string) list_raw[x,1] ;
					}
				return id.ToString() ;
				}
			}
		}
	}