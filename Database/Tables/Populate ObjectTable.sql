SET NOCOUNT ON

exec CreateObject @SfiNumber=722,
					@MainEqNumber='707',
					@EqNumber='01',
					@Description='Main Bilge Pump',
					@VduGroup='Bilge',
					@Hierarchy1='Bilge',
					@Hierarchy2='Oily Bilge',
					@EasGroup='Bilge',
					@AlarmGroup='Machinery',
					@Otd='BO_Motor',
					@ObjectType='Motor',
					@AcknowledgeAllowed='ECR',
					@AlwaysVisible='ECR',
					@Node='PCU1',
					@Cabinet='C01'
exec CreateObject 899,'651','01','Fire valve 1','Fire','Fire System','Deck 1','Fire System','Machinery','BO_Valve','Valve','ECR','ECR','PCU1','C02'
exec CreateObject 909,'707','01','Generator Winding temperature','Thrusters','Propulsion','Thruster Overview','Propulsion','Load Reduction','BO_AnalogIn','Analog sensor','Bridge','Bridge','PCU2', 'C02'

