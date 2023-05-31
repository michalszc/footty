CREATE TABLE IF NOT EXISTS Stadium (
	id INTEGER PRIMARY KEY AUTOINCREMENT, 
	team INTEGER, 
	city TEXT, 
	name TEXT, 
	capacity INTEGER, 
	latitude FLOAT, 
	longitude FLOAT
);

INSERT INTO Stadium (team, city, name, capacity, latitude, longitude) VALUES (1, 'Bilbao ', 'San Mamés ', 53332, 43.264284, -2.950366), (2, 'Madrid ', 'Vicente Calderón ', 54851, 40.401719, -3.720606), (5, 'Barcelona ', 'Camp Nou ', 99354, 41.38087, 2.122802), (13, 'Seville ', 'Benito Villamarín ', 52500, 37.356389, -5.981389), (11, 'Vigo ', 'Balaídos ', 31800, 42.211842, -8.739711), (6, 'Getafe ', 'Coliseum Alfonso Pérez ', 17700, 40.325556, -3.714722), (8, 'Valencia ', 'Ciutat de València ', 25534, 39.494722, -0.364167), (10, 'Madrid ', 'Campo de Vallecas ', 15489, 40.391944, -3.658961), (14, 'Madrid ', 'Santiago Bernabéu ', 85454, 40.45306, -3.68835), (15, 'San Sebastián ', 'Anoeta ', 32076, 43.301378, -1.973617), (18, 'Seville ', 'Ramón Sánchez Pizjuán ', 45500, 37.384, -5.9705), (19, 'Valencia ', 'Mestalla ', 55000, 39.474656, -0.358361), (9, 'Valladolid ', 'Nuevo José Zorrilla ', 26512, 41.644444, -4.761111), (20, 'Villarreal ', 'El Madrigal ', 24890, 39.944167, -0.103611)
