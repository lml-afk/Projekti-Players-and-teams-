# Projekti-Players-and-teams-

My bestest project yet:

Will add data to a database using a sophisticated menu
Will print out said data
-----------------------------------------------------
SQL SCRIPT:
-----------------------------------------------------

drop table if exists player;
drop table if exists manager;

CREATE TABLE public.manager (
    managerid integer NOT NULL,
    firstname character varying(32) NOT NULL,
    lastname character varying(32) NOT NULL,
    team character varying(32) NOT NULL
);

CREATE TABLE public.player (
    player_id integer NOT NULL,
    firstname character varying(32) NOT NULL,
    lastname character varying(32) NOT NULL,
    team character varying(32) NOT NULL,
	score integer NOT NULL
);



ALTER TABLE ONLY public.manager
ADD CONSTRAINT manager_pkey PRIMARY KEY (managerid);
ALTER TABLE ONLY public.player
ADD CONSTRAINT player_pkey PRIMARY KEY (player_id);
	
			
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (1,'Jani','Litmanen','Iisalmen Kisailijat',44);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (2,'Sikari','Sakari','Jumoon Pallo',32);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (3,'Jari','Curry','Juvan veto',42);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (4,'Eerno','Ojanen','Jumoon Pallo',35);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (5,'Jere','Pleijeri','Iisalmen Kisailijat',30);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (6,'Kai','Kanuuna','Nurmon Näppi',5);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (7,'Pekka','Pelaaja','Juvan veto',16);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (8,'Kari','Salakari','Jumoon Pallo',14);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (9,'Seppo','Lovi','Juvan veto',42);
INSERT INTO public.player (player_id,firstname,lastname,team,score) VALUES (10,'Teijo','Latvala','Nurmon Näppi',11);

INSERT INTO public.manager (managerid,firstname,lastname,team) VALUES (1,'Roope','Roponen','Nurmon Näppi');
INSERT INTO public.manager (managerid,firstname,lastname,team) VALUES (2,'Erno','Ojanen','Juval Veto');
INSERT INTO public.manager (managerid,firstname,lastname,team) VALUES (3,'Jaana','Jannula','Jumoon Pallo');
INSERT INTO public.manager (managerid,firstname,lastname,team) VALUES (4,'Sven','Persson','Iisalmen Kisailijat');

/*
DATABASE NAME PlayersTeams
*/
