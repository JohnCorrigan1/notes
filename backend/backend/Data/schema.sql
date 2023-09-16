CREATE TABLE users (
    id serial PRIMARY KEY,
    username VARCHAR(255) NOT NULL
);

CREATE TABLE posts (
    post_id serial PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    body TEXT,
    posted_date TIMESTAMP,
    likes integer,
    author_id integer REFERENCES users(id)
);

CREATE TABLE comments (
    id serial PRIMARY KEY,
    body TEXT,
    posted_date TIMESTAMP,
    likes integer,
    user_id integer REFERENCES users(id),
    post_id integer REFERENCES posts(postId)
);


--show the tables
-- give me some example values to add
-- add some values
-- show the values

drop table comments;
drop table posts;


use notes-app

insert into users (username) values ('joe');
insert into users (username) values ('jane');
insert into users (username) values ('jim');


insert into posts (title, body, postedDate, likes, author_id) values ('first post', 'this is my first post', '2020-01-01', 0, 1);
insert into posts (title, body, postedDate, likes, author_id) values ('second post', 'this is my second post', '2020-01-02', 0, 1);
insert into posts (title, body, postedDate, likes, author_id) values ('third post', 'this is my third post', '2020-01-03', 0, 2);

insert into comments (body, postedDate, user_id, post_id) values ('this is a comment', '2020-01-01', 1, 1);
insert into comments (body, postedDate, user_id, post_id) values ('this is another comment', '2020-01-02', 2, 1);
insert into comments (body, postedDate, user_id, post_id) values ('this is a third comment', '2020-01-03', 1, 2);
