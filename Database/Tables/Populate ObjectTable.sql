exec CreateObject 722,'707','01','Main Bilge Pump','Bilge','Bilge','Oily Bilge','Bilge','Machinery','BO_Motor','ECR','ECR','PCU1','C01'
exec CreateObject 899,'651','01','Fire valve 1','Fire','Fire System','Deck 1','Fire System','Machinery','BO_Valve','ECR','ECR','PCU1','C02'
exec CreateObject 909,'707','01','Generator Winding temperature','Thrusters','Propulsion','Thruster Overview','Propulsion','Load Reduction','BO_AnalogIn','Bridge','Bridge','PCU2', 'C02'

exec CreateTag 1, 01, 'Pump running', 'DI', 'NC',NULL, NULL,NULL,NULL,NULL,NULL, NULL,NULL,'IW5.0',NULL,'db_Pumps',NULL,NULL,1,NULL
exec CreateTag 2, 41, 'Valve Feedback', 'AI', 'Int','%',0,100,10,20,80,90,3,'IW9','valve_path',NULL,NULL,NULL,1,NULL
exec CreateTag 3, 41, 'U1 Temp', 'SAI', 'Int','deg C', 0,100,10,20,80,90,3,NULL,'db_generator',NULL,40005,NULL,1,1

