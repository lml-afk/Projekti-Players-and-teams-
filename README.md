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
	
/*
DATABASE NAME PlayersTeams
*/
