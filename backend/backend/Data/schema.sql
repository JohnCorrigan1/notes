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

INSERT INTO users VALUES (1, 'user1');
INSERT INTO users VALUES (2, 'user2');
INSERT INTO users VALUES (3, 'user3');

INSERT INTO posts VALUES (1, 'My first post', 'This is my first post', '2019-01-01 12:00:00', 0, 1);
INSERT INTO posts VALUES (2, 'My Second post', 'This is my second post', '2019-01-02 12:00:00', 0, 1);
INSERT INTO posts VALUES (3, 'My Third post', 'This is my third post', '2019-01-03 12:00:00', 0, 1);

INSERT INTO comments VALUES (1, 'This is my first comment', '2019-01-01 12:00:00', 0, 1, 1);
INSERT INTO comments VALUES (2, 'This is my second comment', '2019-01-02 12:00:00', 0, 1, 1);
INSERT INTO comments VALUES (3, 'This is my third comment', '2019-01-03 12:00:00', 0, 1, 1);
