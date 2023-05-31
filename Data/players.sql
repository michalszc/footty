CREATE TABLE IF NOT EXISTS Player (
	id INTEGER PRIMARY KEY AUTOINCREMENT, 
	teamid INTEGER REFERENCES Team(id), 
	position TEXT, 
	shirt_number TEXT, 
	minutes_played FLOAT, 
	games_played INTEGER, 
	assists INTEGER, 
	goals_scored INTEGER
);

INSERT INTO Player (teamid, position, shirt_number, minutes_played, games_played, assists, goals_scored) VALUES (1, 'Goalkeeper', '-', 0.0, 0, 0, 0), (1, 'Goalkeeper', 1, 0.0, 0, 0, 0), (1, 'Goalkeeper', 13, 2.79, 31, 1, 0), (1, 'Goalkeeper', 25, 630.0, 7, 0, 0), (1, 'Defender', 3, 1.063, 12, 0, 0), (1, 'Defender', 4, 2.903, 33, 0, 0), (1, 'Defender', 5, 2.614, 30, 0, 0), (1, 'Defender', 6, 1.716, 33, 0, 0), (1, 'Defender', 12, 3.12, 35, 2, 2), (1, 'Defender', 15, 210.0, 4, 0, 0), (1, 'Defender', 24, 520.0, 11, 0, 0), (1, 'Midfielder', '-', 465.0, 8, 0, 2), (1, 'Midfielder', 7, 2.045, 27, 2, 1), (1, 'Midfielder', 8, 97.0, 3, 0, 0), (1, 'Midfielder', 11, 1.322, 23, 5, 0), (1, 'Midfielder', 14, 1.38, 22, 2, 1), (1, 'Midfielder', 16, 2.482, 29, 0, 0), (1, 'Midfielder', 17, 243.0, 4, 0, 0), (1, 'Midfielder', 18, 2.426, 30, 2, 1), (1, 'Midfielder', 19, 2.033, 32, 4, 3), (1, 'Midfielder', 21, 1.637, 25, 0, 0), (1, 'Midfielder', 22, 2.379, 33, 3, 9), (1, 'Midfielder', 23, 325.0, 7, 0, 0), (1, 'Midfielder', 32, 0.0, 0, 0, 0), (1, 'Forward', '-', 45.0, 6, 0, 0), (1, 'Forward', 2, 151.0, 11, 0, 1), (1, 'Forward', 9, 3.036, 38, 4, 13), (1, 'Forward', 10, 2.385, 34, 4, 7), (1, 'Forward', 20, 941.0, 20, 0, 2), (2, 'Goalkeeper', '-', 0.0, 0, 0, 0), (2, 'Goalkeeper', 1, 90.0, 1, 0, 0), (2, 'Goalkeeper', 13, 3.33, 37, 0, 0), (2, 'Defender', 2, 2.507, 30, 1, 3), (2, 'Defender', 3, 2.037, 27, 2, 2), (2, 'Defender', 4, 1.77, 25, 1, 1), (2, 'Defender', 15, 1.399, 18, 2, 0), (2, 'Defender', 18, 0.0, 0, 0, 0), (2, 'Defender', 20, 1.609, 22, 2, 0), (2, 'Defender', 21, 1.118, 14, 0, 1), (2, 'Defender', 24, 1.772, 21, 0, 0), (2, 'Defender', 33, 45.0, 1, 0, 0), (2, 'Defender', 35, 401.0, 9, 0, 0), (2, 'Defender', 54, 0.0, 0, 0, 0), (2, 'Midfielder', 5, 2.064, 32, 4, 3), (2, 'Midfielder', 6, 2.587, 30, 4, 3), (2, 'Midfielder', 8, 2.925, 33, 1, 4), (2, 'Midfielder', 14, 2.742, 34, 1, 3), (2, 'Midfielder', 28, 0.0, 0, 0, 0), (2, 'Midfielder', 30, 0.0, 0, 0, 0), (2, 'Midfielder', 32, 19.0, 1, 0, 1), (2, 'Midfielder', 40, 62.0, 4, 0, 0), (2, 'Midfielder', 47, 1.0, 1, 0, 0), (2, 'Midfielder', 55, 45.0, 1, 0, 1), (2, 'Midfielder', 57, 0.0, 0, 0, 0), (2, 'Forward', 7, 3.202, 37, 9, 15), (2, 'Forward', 9, 639.0, 17, 0, 2), (2, 'Forward', 10, 1.92, 36, 2, 3), (2, 'Forward', 11, 1.827, 31, 3, 3), (2, 'Forward', 19, 1.114, 16, 2, 2), (2, 'Forward', 22, 1.089, 15, 1, 6), (2, 'Forward', 23, 744.0, 20, 1, 0), (3, 'Goalkeeper', 1, 3.056, 34, 0, 0), (3, 'Goalkeeper', 13, 0.0, 0, 0, 0), (3, 'Goalkeeper', 29, 364.0, 5, 0, 0), (3, 'Goalkeeper', 31, 0.0, 0, 0, 0), (3, 'Defender', 2, 1.459, 23, 1, 1), (3, 'Defender', 3, 2.029, 25, 1, 0), (3, 'Defender', 4, 319.0, 6, 0, 0), (3, 'Defender', 5, 2.7, 30, 6, 3), (3, 'Defender', 12, 1.712, 23, 1, 1), (3, 'Defender', 14, 484.0, 6, 0, 0), (3, 'Defender', 15, 1.429, 18, 0, 0), (3, 'Defender', 19, 211.0, 3, 0, 0), (3, 'Defender', 22, 2.963, 34, 0, 1), (3, 'Defender', 24, 2.434, 28, 0, 0), (3, 'Midfielder', '-', 2.515, 31, 3, 4), (3, 'Midfielder', 6, 1.196, 16, 1, 1), (3, 'Midfielder', 8, 1.287, 18, 0, 0), (3, 'Midfielder', 10, 954.0, 27, 0, 4), (3, 'Midfielder', 11, 9.0, 1, 0, 0), (3, 'Midfielder', 17, 635.0, 13, 0, 0), (3, 'Midfielder', 21, 2.471, 31, 0, 0), (3, 'Midfielder', 23, 2.075, 26, 1, 1), (3, 'Midfielder', 33, 0.0, 0, 0, 0), (3, 'Forward', '-', 2.104, 31, 2, 9), (3, 'Forward', 9, 1.995, 32, 1, 6), (3, 'Forward', 16, 108.0, 6, 0, 0), (3, 'Forward', 18, 288.0, 12, 0, 0), (3, 'Forward', 20, 552.0, 16, 3, 1), (3, 'Forward', 25, 1.407, 19, 5, 4), (4, 'Goalkeeper', 1, 3.15, 35, 0, 0), (4, 'Goalkeeper', 13, 270.0, 3, 0, 0), (4, 'Goalkeeper', 31, 0.0, 0, 0, 0), (4, 'Defender', 2, 646.0, 8, 0, 0), (4, 'Defender', 3, 2.775, 33, 0, 0), (4, 'Defender', 4, 431.0, 5, 0, 0), (4, 'Defender', 5, 3.24, 36, 2, 1), (4, 'Defender', 6, 2.008, 23, 2, 2), (4, 'Defender', 15, 2.533, 31, 2, 2), (4, 'Defender', 17, 287.0, 6, 0, 0), (4, 'Defender', 21, 2.034, 27, 0, 0), (4, 'Midfielder', '-', 14.0, 2, 0, 0), (4, 'Midfielder', 8, 2.343, 28, 0, 2), (4, 'Midfielder', 11, 1.211, 20, 0, 2), (4, 'Midfielder', 19, 2.325, 34, 1, 1), (4, 'Midfielder', 20, 1.581, 24, 1, 0), (4, 'Midfielder', 22, 1.664, 29, 1, 1), (4, 'Midfielder', 23, 2.982, 36, 10, 5), (4, 'Midfielder', 32, 0.0, 0, 0, 0), (4, 'Midfielder', 34, 0.0, 0, 0, 0), (4, 'Forward', 9, 507.0, 15, 0, 0), (4, 'Forward', 10, 621.0, 22, 1, 2), (4, 'Forward', 12, 2.876, 34, 2, 9), (4, 'Forward', 14, 547.0, 16, 0, 1), (4, 'Forward', 18, 1.449, 27, 1, 5), (4, 'Forward', 24, 159.0, 11, 0, 0), (5, 'Goalkeeper', 1, 3.15, 35, 0, 0), (5, 'Goalkeeper', 13, 270.0, 3, 0, 0), (5, 'Goalkeeper', 30, 0.0, 0, 0, 0), (5, 'Defender', '-', 202.0, 3, 0, 0), (5, 'Defender', 2, 1.597, 26, 0, 1), (5, 'Defender', 3, 3.15, 35, 2, 4), (5, 'Defender', 6, 158.0, 2, 0, 0), (5, 'Defender', 15, 1.935, 23, 0, 1), (5, 'Defender', 18, 2.988, 36, 8, 2), (5, 'Defender', 20, 2.088, 29, 7, 0), (5, 'Defender', 23, 1.19, 14, 1, 0), (5, 'Defender', 24, 587.0, 9, 0, 0), (5, 'Defender', 33, 0.0, 0, 0, 0), (5, 'Defender', 38, 0.0, 0, 0, 0), (5, 'Midfielder', 4, 2.643, 34, 5, 3), (5, 'Midfielder', 5, 2.719, 35, 1, 0), (5, 'Midfielder', 7, 2.022, 34, 2, 5), (5, 'Midfielder', 8, 1.439, 27, 1, 0), (5, 'Midfielder', 12, 225.0, 5, 0, 0), (5, 'Midfielder', 21, 631.0, 17, 0, 2), (5, 'Midfielder', 22, 1.927, 33, 7, 3), (5, 'Forward', 9, 2.827, 33, 6, 21), (5, 'Forward', 10, 2.71, 34, 13, 36), (5, 'Forward', 11, 1.671, 29, 5, 8), (5, 'Forward', 14, 608.0, 15, 2, 1), (5, 'Forward', 19, 240.0, 3, 0, 0), (6, 'Goalkeeper', 1, 90.0, 1, 0, 0), (6, 'Goalkeeper', 13, 3.33, 37, 0, 0), (6, 'Goalkeeper', 25, 0.0, 0, 0, 0), (6, 'Defender', 2, 2.98, 34, 0, 0), (6, 'Defender', 3, 2.182, 28, 3, 1), (6, 'Defender', 4, 1.697, 23, 1, 0), (6, 'Defender', 6, 2.793, 32, 0, 2), (6, 'Defender', 17, 1.01, 14, 1, 0), (6, 'Defender', 21, 317.0, 7, 0, 0), (6, 'Defender', 22, 3.24, 36, 3, 0), (6, 'Defender', 24, 1.809, 25, 2, 3), (6, 'Defender', 29, 0.0, 0, 0, 0), (6, 'Midfielder', 5, 50.0, 3, 0, 0), (6, 'Midfielder', 8, 1.991, 32, 4, 1), (6, 'Midfielder', 10, 389.0, 7, 0, 0), (6, 'Midfielder', 11, 299.0, 10, 0, 1), (6, 'Midfielder', 15, 442.0, 15, 2, 0), (6, 'Midfielder', 16, 449.0, 10, 0, 0), (6, 'Midfielder', 18, 2.685, 33, 2, 1), (6, 'Midfielder', 20, 3.211, 36, 0, 1), (6, 'Midfielder', 27, 414.0, 11, 0, 0), (6, 'Forward', 7, 2.436, 34, 6, 14), (6, 'Forward', 9, 1.82, 37, 3, 8), (6, 'Forward', 19, 2.647, 38, 5, 14), (7, 'Goalkeeper', '-', 0.0, 0, 0, 0), (7, 'Goalkeeper', 1, 558.0, 7, 0, 0), (7, 'Goalkeeper', 13, 2.862, 32, 0, 0), (7, 'Defender', 2, 2.729, 31, 1, 1), (7, 'Defender', 3, 19.0, 1, 0, 0), (7, 'Defender', 4, 1.619, 22, 0, 1), (7, 'Defender', 5, 1.868, 25, 1, 1), (7, 'Defender', 11, 647.0, 10, 2, 0), (7, 'Defender', 14, 1.234, 15, 1, 0), (7, 'Defender', 15, 2.769, 33, 0, 0), (7, 'Defender', 20, 1.403, 19, 0, 0), (7, 'Defender', 21, 418.0, 7, 1, 0), (7, 'Defender', 28, 0.0, 0, 0, 0), (7, 'Midfielder', '-', 78.0, 5, 0, 0), (7, 'Midfielder', '-', 58.0, 3, 0, 0), (7, 'Midfielder', '-', 0.0, 0, 0, 0), (7, 'Midfielder', 6, 2.392, 32, 4, 0), (7, 'Midfielder', 8, 2.796, 34, 2, 1), (7, 'Midfielder', 10, 2.636, 33, 3, 1), (7, 'Midfielder', 12, 1.487, 23, 0, 0), (7, 'Midfielder', 17, 594.0, 19, 0, 0), (7, 'Midfielder', 23, 1.665, 31, 1, 2), (7, 'Midfielder', 24, 2.212, 32, 4, 0), (7, 'Midfielder', 34, 884.0, 17, 1, 0), (7, 'Midfielder', 37, 0.0, 0, 0, 0), (7, 'Forward', 7, 2.731, 32, 0, 19), (7, 'Forward', 9, 2.833, 34, 2, 9), (7, 'Forward', 19, 725.0, 20, 0, 0), (7, 'Forward', 22, 535.0, 17, 0, 2), (8, 'Goalkeeper', 1, 90.0, 1, 0, 0), (8, 'Goalkeeper', 13, 1.89, 21, 0, 0), (8, 'Goalkeeper', 25, 1.44, 16, 0, 0), (8, 'Defender', '-', 0.0, 0, 0, 0), (8, 'Defender', 3, 1.767, 21, 2, 1), (8, 'Defender', 4, 2.855, 33, 0, 1), (8, 'Defender', 6, 1.251, 19, 0, 2), (8, 'Defender', 12, 1.815, 27, 0, 4), (8, 'Defender', 14, 1.534, 19, 1, 2), (8, 'Defender', 15, 1.45, 21, 1, 1), (8, 'Defender', 18, 1.638, 21, 0, 2), (8, 'Defender', 19, 463.0, 8, 1, 0), (8, 'Defender', 22, 1.259, 16, 2, 0), (8, 'Midfielder', 5, 313.0, 9, 0, 0), (8, 'Midfielder', 10, 2.841, 36, 4, 3), (8, 'Midfielder', 11, 3.197, 37, 5, 12), (8, 'Midfielder', 16, 1.812, 27, 5, 4), (8, 'Midfielder', 17, 670.0, 16, 1, 0), (8, 'Midfielder', 23, 2.331, 30, 5, 2), (8, 'Midfielder', 24, 3.213, 36, 9, 4), (8, 'Midfielder', 27, 155.0, 4, 0, 0), (8, 'Midfielder', 31, 0.0, 0, 0, 0), (8, 'Forward', 2, 1.614, 29, 2, 3), (8, 'Forward', 7, 779.0, 19, 1, 1), (8, 'Forward', 9, 1.894, 31, 0, 13), (8, 'Forward', 20, 213.0, 12, 1, 0), (9, 'Goalkeeper', 1, 3.15, 35, 0, 0), (9, 'Goalkeeper', 13, 270.0, 3, 0, 0), (9, 'Defender', 2, 836.0, 13, 0, 1), (9, 'Defender', 3, 270.0, 3, 0, 0), (9, 'Defender', 4, 3.102, 35, 0, 0), (9, 'Defender', 5, 3.13, 36, 0, 1), (9, 'Defender', 17, 2.106, 27, 0, 0), (9, 'Defender', 18, 1.854, 30, 1, 2), (9, 'Defender', 22, 3.15, 35, 3, 1), (9, 'Defender', 28, 0.0, 0, 0, 0), (9, 'Defender', 34, 0.0, 0, 0, 0), (9, 'Defender', 38, 0.0, 0, 0, 0), (9, 'Midfielder', '-', 341.0, 6, 1, 0), (9, 'Midfielder', 6, 0.0, 0, 0, 0), (9, 'Midfielder', 7, 493.0, 8, 0, 1), (9, 'Midfielder', 8, 839.0, 19, 0, 0), (9, 'Midfielder', 10, 2.696, 33, 4, 3), (9, 'Midfielder', 11, 641.0, 22, 0, 2), (9, 'Midfielder', 14, 2.978, 34, 2, 3), (9, 'Midfielder', 19, 1.774, 26, 2, 2), (9, 'Midfielder', 21, 2.551, 35, 2, 1), (9, 'Midfielder', 23, 1.082, 19, 0, 1), (9, 'Midfielder', 24, 1.543, 26, 1, 2), (9, 'Midfielder', 27, 11.0, 2, 0, 0), (9, 'Midfielder', 31, 0.0, 0, 0, 0), (9, 'Midfielder', 37, 2.0, 1, 0, 0), (9, 'Forward', 9, 2.15, 33, 3, 6), (9, 'Forward', 12, 1.544, 20, 1, 3), (9, 'Forward', 20, 679.0, 18, 0, 0), (9, 'Forward', 42, 36.0, 2, 0, 0), (10, 'Goalkeeper', 1, 1.53, 17, 0, 0), (10, 'Goalkeeper', 13, 1.89, 21, 0, 0), (10, 'Goalkeeper', 30, 0.0, 0, 0, 0), (10, 'Defender', '-', 177.0, 2, 0, 0), (10, 'Defender', '-', 180.0, 2, 1, 0), (10, 'Defender', 2, 1.099, 15, 0, 0), (10, 'Defender', 7, 3.139, 36, 1, 1), (10, 'Defender', 16, 2.764, 31, 0, 0), (10, 'Defender', 17, 2.391, 28, 3, 1), (10, 'Defender', 20, 1.275, 18, 2, 0), (10, 'Defender', 21, 2.111, 26, 0, 1), (10, 'Defender', 23, 1.418, 17, 0, 1), (10, 'Defender', 31, 0.0, 0, 0, 0), (10, 'Defender', 33, 0.0, 0, 0, 0), (10, 'Midfielder', '-', 2.032, 25, 1, 1), (10, 'Midfielder', 3, 372.0, 6, 0, 0), (10, 'Midfielder', 4, 1.147, 21, 0, 3), (10, 'Midfielder', 6, 285.0, 5, 0, 0), (10, 'Midfielder', 10, 720.0, 12, 0, 1), (10, 'Midfielder', 12, 1.739, 22, 1, 1), (10, 'Midfielder', 14, 1.358, 29, 1, 1), (10, 'Midfielder', 15, 1.026, 14, 0, 2), (10, 'Midfielder', 18, 1.759, 35, 2, 4), (10, 'Midfielder', 22, 1.612, 29, 0, 3), (10, 'Midfielder', 25, 169.0, 6, 0, 0), (10, 'Midfielder', 34, 0.0, 0, 0, 0), (10, 'Midfielder', 35, 0.0, 0, 0, 0), (10, 'Forward', 8, 1.772, 26, 4, 1), (10, 'Forward', 9, 2.818, 33, 1, 14), (10, 'Forward', 11, 2.289, 36, 6, 5), (10, 'Forward', 19, 0.0, 0, 0, 0), (10, 'Forward', 24, 231.0, 8, 1, 0), (10, 'Forward', 29, 13.0, 1, 0, 0), (11, 'Goalkeeper', 1, 1.17, 13, 0, 0), (11, 'Goalkeeper', 13, 2.25, 25, 0, 0), (11, 'Goalkeeper', 26, 0.0, 0, 0, 0), (11, 'Defender', '-', 898.0, 10, 2, 0), (11, 'Defender', 2, 3.094, 35, 4, 1), (11, 'Defender', 3, 1.173, 15, 0, 0), (11, 'Defender', 4, 2.682, 32, 0, 3), (11, 'Defender', 12, 893.0, 10, 0, 0), (11, 'Defender', 17, 1.758, 21, 3, 0), (11, 'Defender', 20, 218.0, 4, 0, 0), (11, 'Defender', 22, 1.897, 24, 0, 0), (11, 'Midfielder', 5, 2.203, 30, 0, 2), (11, 'Midfielder', 6, 0.0, 0, 0, 0), (11, 'Midfielder', 7, 366.0, 10, 0, 0), (11, 'Midfielder', 8, 1.512, 30, 0, 1), (11, 'Midfielder', 14, 2.493, 31, 1, 0), (11, 'Midfielder', 16, 349.0, 15, 3, 0), (11, 'Midfielder', 18, 235.0, 6, 0, 0), (11, 'Midfielder', 19, 2.097, 35, 3, 3), (11, 'Midfielder', 21, 1.157, 20, 0, 0), (11, 'Midfielder', 23, 2.351, 31, 7, 6), (11, 'Midfielder', 24, 1.26, 20, 2, 1), (11, 'Forward', 9, 2.961, 35, 5, 13), (11, 'Forward', 10, 2.258, 27, 6, 20), (11, 'Forward', 11, 834.0, 25, 1, 2), (12, 'Goalkeeper', 1, 0.0, 0, 0, 0), (12, 'Goalkeeper', 13, 3.42, 38, 0, 0), (12, 'Defender', '-', 520.0, 6, 0, 0), (12, 'Defender', 5, 1.366, 16, 1, 1), (12, 'Defender', 6, 657.0, 11, 0, 0), (12, 'Defender', 8, 1.751, 21, 1, 3), (12, 'Defender', 12, 2.358, 27, 2, 0), (12, 'Defender', 16, 1.947, 23, 0, 0), (12, 'Defender', 22, 2.806, 32, 0, 3), (12, 'Defender', 28, 760.0, 12, 0, 1), (12, 'Defender', 32, 0.0, 0, 0, 0), (12, 'Midfielder', '-', 42.0, 3, 0, 0), (12, 'Midfielder', '-', 204.0, 9, 0, 1), (12, 'Midfielder', 4, 1.257, 24, 2, 0), (12, 'Midfielder', 10, 2.717, 34, 2, 4), (12, 'Midfielder', 14, 2.002, 32, 5, 0), (12, 'Midfielder', 15, 1.82, 21, 0, 0), (12, 'Midfielder', 18, 109.0, 4, 0, 0), (12, 'Midfielder', 21, 3.116, 35, 2, 1), (12, 'Midfielder', 23, 2.019, 28, 1, 3), (12, 'Midfielder', 29, 0.0, 0, 0, 0), (12, 'Midfielder', 31, 0.0, 0, 0, 0), (12, 'Forward', 7, 3.081, 37, 3, 17), (12, 'Forward', 9, 1.487, 29, 1, 2), (12, 'Forward', 17, 797.0, 19, 2, 1), (12, 'Forward', 19, 734.0, 20, 0, 1), (12, 'Forward', 20, 348.0, 15, 0, 0), (12, 'Forward', 24, 1.064, 16, 1, 3), (13, 'Goalkeeper', 1, 450.0, 5, 0, 0), (13, 'Goalkeeper', 13, 2.97, 33, 0, 0), (13, 'Defender', '-', 317.0, 6, 0, 0), (13, 'Defender', 2, 1.79, 22, 1, 0), (13, 'Defender', 4, 1.701, 21, 1, 1), (13, 'Defender', 5, 2.93, 33, 0, 1), (13, 'Defender', 12, 1.743, 24, 0, 1), (13, 'Defender', 19, 936.0, 14, 0, 0), (13, 'Defender', 20, 1.937, 24, 4, 3), (13, 'Defender', 23, 3.06, 35, 1, 1), (13, 'Defender', 30, 0.0, 0, 0, 0), (13, 'Defender', 32, 0.0, 0, 0, 0), (13, 'Midfielder', '-', 776.0, 10, 0, 0), (13, 'Midfielder', 3, 520.0, 13, 0, 0), (13, 'Midfielder', 6, 2.658, 32, 2, 7), (13, 'Midfielder', 11, 1.559, 29, 6, 4), (13, 'Midfielder', 14, 2.386, 30, 5, 0), (13, 'Midfielder', 17, 1.694, 30, 0, 6), (13, 'Midfielder', 18, 2.338, 31, 4, 0), (13, 'Midfielder', 21, 2.4, 32, 4, 9), (13, 'Midfielder', 22, 348.0, 12, 1, 0), (13, 'Midfielder', 27, 0.0, 0, 0, 0), (13, 'Midfielder', 28, 0.0, 0, 0, 0), (13, 'Midfielder', 33, 0.0, 0, 0, 0), (13, 'Midfielder', 37, 0.0, 0, 0, 0), (13, 'Midfielder', 37, 0.0, 0, 0, 0), (13, 'Midfielder', 38, 0.0, 0, 0, 0), (13, 'Forward', 7, 632.0, 16, 1, 0), (13, 'Forward', 10, 782.0, 14, 0, 2), (13, 'Forward', 16, 1.958, 33, 0, 6), (14, 'Goalkeeper', '-', 90.0, 1, 0, 0), (14, 'Goalkeeper', 1, 900.0, 10, 0, 0), (14, 'Goalkeeper', 25, 2.43, 27, 0, 0), (14, 'Defender', '-', 45.0, 1, 0, 0), (14, 'Defender', 2, 2.106, 24, 2, 1), (14, 'Defender', 3, 311.0, 5, 0, 1), (14, 'Defender', 4, 2.474, 28, 1, 6), (14, 'Defender', 5, 2.755, 32, 0, 2), (14, 'Defender', 6, 1.701, 20, 1, 0), (14, 'Defender', 12, 1.841, 23, 2, 2), (14, 'Defender', 19, 1.179, 14, 2, 0), (14, 'Defender', 23, 1.121, 14, 2, 0), (14, 'Defender', 26, 0.0, 0, 0, 0), (14, 'Defender', 37, 0.0, 0, 0, 0), (14, 'Midfielder', 8, 2.227, 28, 4, 0), (14, 'Midfielder', 10, 2.617, 34, 6, 3), (14, 'Midfielder', 14, 2.316, 29, 0, 3), (14, 'Midfielder', 15, 651.0, 16, 0, 0), (14, 'Midfielder', 18, 540.0, 7, 0, 0), (14, 'Midfielder', 20, 1.778, 30, 4, 1), (14, 'Midfielder', 21, 378.0, 9, 1, 1), (14, 'Midfielder', 22, 1.186, 27, 2, 3), (14, 'Midfielder', 24, 1.246, 23, 0, 3), (14, 'Midfielder', 36, 0.0, 0, 0, 0), (14, 'Midfielder', 39, 0.0, 0, 0, 0), (14, 'Forward', '-', 45.0, 1, 0, 0), (14, 'Forward', 7, 439.0, 13, 0, 3), (14, 'Forward', 9, 2.961, 36, 6, 21), (14, 'Forward', 11, 1.792, 29, 3, 8), (14, 'Forward', 17, 1.501, 31, 3, 1), (14, 'Forward', 28, 864.0, 18, 0, 2), (15, 'Goalkeeper', '-', 0.0, 0, 0, 0), (15, 'Goalkeeper', 1, 2.43, 27, 0, 0), (15, 'Goalkeeper', 13, 990.0, 11, 0, 0), (15, 'Defender', 2, 2.141, 26, 2, 1), (15, 'Defender', 3, 1.755, 21, 0, 0), (15, 'Defender', 6, 1.929, 25, 0, 1), (15, 'Defender', 15, 2.253, 27, 0, 1), (15, 'Defender', 18, 454.0, 7, 0, 0), (15, 'Defender', 19, 1.976, 24, 2, 1), (15, 'Defender', 20, 483.0, 7, 0, 0), (15, 'Defender', 22, 1.311, 16, 0, 0), (15, 'Defender', 27, 283.0, 4, 1, 0), (15, 'Defender', 29, 954.0, 11, 0, 0), (15, 'Defender', 35, 90.0, 1, 0, 0), (15, 'Midfielder', '-', 90.0, 1, 0, 0), (15, 'Midfielder', 4, 1.822, 23, 1, 1), (15, 'Midfielder', 5, 2.551, 33, 1, 0), (15, 'Midfielder', 8, 2.06, 29, 3, 3), (15, 'Midfielder', 14, 1.373, 24, 2, 1), (15, 'Midfielder', 16, 4.0, 1, 0, 0), (15, 'Midfielder', 17, 1.223, 21, 0, 2), (15, 'Midfielder', 23, 999.0, 18, 3, 1), (15, 'Midfielder', 28, 28.0, 1, 0, 0), (15, 'Midfielder', 31, 0.0, 0, 0, 0), (15, 'Midfielder', 34, 398.0, 9, 0, 1), (15, 'Midfielder', 36, 6.0, 1, 0, 0), (15, 'Midfielder', 38, 0.0, 0, 0, 0), (15, 'Forward', 7, 1.52, 30, 2, 5), (15, 'Forward', 10, 3.159, 37, 2, 13), (15, 'Forward', 11, 1.252, 20, 3, 1), (15, 'Forward', 12, 2.374, 31, 5, 11), (15, 'Forward', 21, 587.0, 18, 0, 1), (15, 'Forward', 24, 1.05, 24, 0, 0), (16, 'Goalkeeper', 1, 2.16, 24, 0, 0), (16, 'Goalkeeper', 13, 1.26, 14, 0, 0), (16, 'Defender', 2, 1.0, 1, 0, 0), (16, 'Defender', 3, 584.0, 10, 1, 0), (16, 'Defender', 4, 1.682, 21, 0, 0), (16, 'Defender', 12, 2.243, 28, 0, 0), (16, 'Defender', 15, 3.034, 35, 1, 1), (16, 'Defender', 20, 2.356, 31, 2, 1), (16, 'Defender', 23, 1.95, 25, 2, 1), (16, 'Midfielder', 5, 1.782, 32, 1, 4), (16, 'Midfielder', 6, 1.064, 19, 0, 0), (16, 'Midfielder', 8, 2.356, 28, 1, 1), (16, 'Midfielder', 11, 2.673, 31, 2, 1), (16, 'Midfielder', 14, 2.738, 33, 5, 3), (16, 'Midfielder', 16, 1.517, 24, 0, 2), (16, 'Midfielder', 21, 426.0, 9, 0, 1), (16, 'Midfielder', 22, 344.0, 5, 0, 0), (16, 'Midfielder', 24, 2.878, 36, 4, 4), (16, 'Midfielder', 29, 67.0, 2, 0, 0), (16, 'Forward', 7, 597.0, 17, 1, 3), (16, 'Forward', 9, 2.592, 35, 4, 7), (16, 'Forward', 17, 1.294, 30, 0, 3), (16, 'Forward', 19, 1.734, 34, 1, 14), (17, 'Goalkeeper', 1, 0.0, 0, 0, 0), (17, 'Goalkeeper', 13, 1.8, 20, 0, 0), (17, 'Goalkeeper', 25, 1.08, 12, 0, 0), (17, 'Defender', 2, 699.0, 9, 0, 2), (17, 'Defender', 3, 2.678, 31, 0, 4), (17, 'Defender', 4, 749.0, 9, 0, 0), (17, 'Defender', 14, 2.788, 32, 3, 3), (17, 'Defender', 15, 1.012, 13, 0, 0), (17, 'Defender', 16, 509.0, 7, 0, 0), (17, 'Defender', 18, 779.0, 10, 0, 0), (17, 'Defender', 24, 2.496, 30, 0, 1), (17, 'Midfielder', 5, 347.0, 6, 0, 0), (17, 'Midfielder', 6, 3.061, 36, 7, 2), (17, 'Midfielder', 7, 2.276, 35, 3, 1), (17, 'Midfielder', 8, 1.346, 22, 1, 2), (17, 'Midfielder', 10, 34.0, 3, 0, 0), (17, 'Midfielder', 11, 1.002, 25, 1, 4), (17, 'Midfielder', 12, 1.44, 16, 2, 0), (17, 'Midfielder', 17, 1.694, 22, 0, 2), (17, 'Midfielder', 20, 672.0, 14, 2, 2), (17, 'Midfielder', 21, 1.158, 16, 0, 0), (17, 'Midfielder', 23, 1.687, 24, 0, 0), (17, 'Forward', 9, 2.15, 34, 3, 4), (17, 'Forward', 19, 1.993, 34, 2, 10), (17, 'Forward', 22, 1.541, 19, 1, 5), (18, 'Goalkeeper', 1, 2.97, 33, 0, 0), (18, 'Goalkeeper', 13, 359.0, 4, 0, 0), (18, 'Goalkeeper', 39, 90.0, 1, 0, 0), (18, 'Defender', 3, 2.766, 32, 0, 0), (18, 'Defender', 4, 2.015, 26, 0, 0), (18, 'Defender', 6, 2.132, 24, 1, 1), (18, 'Defender', 14, 536.0, 7, 0, 0), (18, 'Defender', 18, 1.549, 21, 1, 0), (18, 'Defender', 23, 633.0, 9, 0, 0), (18, 'Defender', 24, 444.0, 7, 0, 0), (18, 'Defender', 25, 1.737, 23, 1, 2), (18, 'Midfielder', 5, 757.0, 17, 0, 0), (18, 'Midfielder', 7, 1.745, 31, 2, 2), (18, 'Midfielder', 10, 2.676, 32, 4, 3), (18, 'Midfielder', 11, 526.0, 11, 0, 0), (18, 'Midfielder', 15, 536.0, 10, 0, 0), (18, 'Midfielder', 16, 2.712, 32, 5, 1), (18, 'Midfielder', 17, 2.728, 33, 13, 12), (18, 'Midfielder', 20, 354.0, 10, 0, 0), (18, 'Midfielder', 22, 2.287, 34, 4, 3), (18, 'Midfielder', 41, 157.0, 11, 1, 1), (18, 'Forward', 8, 73.0, 4, 0, 0), (18, 'Forward', 9, 2.819, 35, 9, 18), (18, 'Forward', 12, 2.163, 27, 0, 9), (18, 'Forward', 19, 1.192, 23, 2, 6), (18, 'Forward', 21, 1.569, 33, 3, 2), (19, 'Goalkeeper', 1, 360.0, 4, 0, 0), (19, 'Goalkeeper', 13, 3.06, 34, 0, 0), (19, 'Defender', 4, 1.674, 19, 0, 0), (19, 'Defender', 5, 2.625, 30, 1, 0), (19, 'Defender', 12, 1.574, 22, 0, 2), (19, 'Defender', 14, 3.138, 35, 1, 1), (19, 'Defender', 15, 270.0, 4, 0, 0), (19, 'Defender', 21, 1.868, 23, 0, 1), (19, 'Defender', 24, 2.137, 24, 0, 2), (19, 'Defender', 36, 0.0, 0, 0, 0), (19, 'Midfielder', 6, 1.244, 19, 1, 1), (19, 'Midfielder', 7, 1.469, 25, 3, 5), (19, 'Midfielder', 8, 2.466, 31, 6, 2), (19, 'Midfielder', 10, 3.062, 36, 7, 9), (19, 'Midfielder', 11, 1.709, 27, 2, 2), (19, 'Midfielder', 16, 21.0, 3, 0, 0), (19, 'Midfielder', 17, 1.766, 26, 1, 0), (19, 'Midfielder', 18, 2.355, 32, 3, 1), (19, 'Midfielder', 37, 0.0, 0, 0, 0), (19, 'Forward', 9, 1.605, 33, 1, 6), (19, 'Forward', 19, 2.534, 33, 6, 8), (19, 'Forward', 20, 843.0, 24, 1, 2), (19, 'Forward', 22, 1.858, 30, 5, 7), (19, 'Forward', 23, 1.155, 24, 1, 3), (20, 'Goalkeeper', 1, 2.88, 32, 0, 0), (20, 'Goalkeeper', 13, 540.0, 6, 0, 0), (20, 'Goalkeeper', 25, 0.0, 0, 0, 0), (20, 'Defender', '-', 628.0, 7, 0, 0), (20, 'Defender', 2, 2.601, 31, 2, 1), (20, 'Defender', 3, 2.965, 33, 2, 1), (20, 'Defender', 4, 2.628, 31, 1, 2), (20, 'Defender', 6, 1.976, 22, 0, 0), (20, 'Defender', 11, 1.498, 21, 0, 1), (20, 'Defender', 15, 543.0, 8, 0, 0), (20, 'Defender', 23, 233.0, 5, 0, 0), (20, 'Midfielder', '-', 611.0, 10, 3, 0), (20, 'Midfielder', 5, 1.588, 23, 1, 0), (20, 'Midfielder', 8, 2.483, 35, 3, 2), (20, 'Midfielder', 10, 1.667, 19, 1, 3), (20, 'Midfielder', 14, 1.547, 24, 0, 0), (20, 'Midfielder', 16, 2.087, 34, 3, 3), (20, 'Midfielder', 18, 234.0, 5, 0, 0), (20, 'Midfielder', 19, 2.651, 35, 10, 4), (20, 'Midfielder', 21, 0.0, 0, 0, 0), (20, 'Midfielder', 22, 186.0, 8, 1, 0), (20, 'Midfielder', 30, 1.708, 26, 2, 5), (20, 'Midfielder', 37, 0.0, 0, 0, 0), (20, 'Midfielder', 42, 0.0, 0, 0, 0), (20, 'Forward', 7, 2.317, 35, 1, 8), (20, 'Forward', 9, 1.259, 33, 1, 6), (20, 'Forward', 17, 2.148, 34, 1, 10)