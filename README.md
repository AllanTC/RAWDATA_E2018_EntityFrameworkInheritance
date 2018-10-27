## Entity Framework Inheritance
There are three different ways to handle inheritance in the relational model, Table Per Hierarchy (TPH), Table Per Type (TPT), 
and Table Per Concrete Class (TPC). Entity framework only supports the two first TPH and TPT. However, the last one, TPC, can easily be 
handled in our example, since posts are static and thus the two concrete clases Question and Answer are just mapped to the tables 
with the respective information. Getting all posts can easily be handled with a database view, but if data is dynamic and new 
entities are inserted one need to ensure that the new postid is unique across both tables. This can be handled by triggers or rules in the database or, less efficient, in the data service layer.

Here are the example database used in the examples showing how to implement the three inheritance models with EF:

```SQL
-- drop database inheritance_example;
--create database inheritance_example;

drop table if exists posts_tph;

create table posts_tph(
	postid int primary key,
	posttypeid int,
	parentid int,
	body varchar(50),
	score int,
	title varchar(50)
);

insert into posts_tph values(1, 1, null, 'aaaa', 123, 'aaa');
insert into posts_tph values(2, 1, null, 'bbbb', 123, 'aaa');
insert into posts_tph values(3, 2, 1, 'cccc', 123, null);
insert into posts_tph values(4, 2, 2, 'dddd', 123, null);

drop table if exists questions_tpt;
drop table if exists answers_tpt;
drop table if exists posts_tpt;

create table posts_tpt(
	postid int primary key,
	body varchar(50),
	score int
);

insert into posts_tpt values(1, 'aaaa', 123);
insert into posts_tpt values(2, 'bbbb', 123);
insert into posts_tpt values(3, 'cccc', 123);
insert into posts_tpt values(4, 'dddd', 123);


create table questions_tpt(
	postid int primary key references posts_tpt(postid),
	title varchar(50)
);

insert into questions_tpt values(1, 'aaa');
insert into questions_tpt values(2, 'bbb');


create table answers_tpt(
	postid int primary key references posts_tpt(postid),
	parentid int
);

insert into answers_tpt values(3, 1);
insert into answers_tpt values(4, 2);

drop table if exists questions_tpc;

create table questions_tpc(
	postid int primary key,
	body varchar(50),
	score int,
	title varchar(50)
);

insert into questions_tpc values(1, 'aaaa', 123, 'aaa');
insert into questions_tpc values(2, 'bbbb', 123, 'aaa');

drop table if exists answers_tpc;

create table answers_tpc(
	postid int primary key,
	parentid int,
	body varchar(50),
	score int
);

insert into answers_tpc values(3, 1, 'cccc', 123);
insert into answers_tpc values(4, 2, 'dddd', 123);
```
