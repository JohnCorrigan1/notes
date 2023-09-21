CREATE TABLE users (
    id serial PRIMARY KEY,
    username VARCHAR(255) NOT NULL
);

CREATE TABLE postmetadata (
  id SERIAL PRIMARY KEY,
  slug VARCHAR(255) UNIQUE NOT NULL,
  title VARCHAR(255) NOT NULL,
  postedDate DATE NOT NULL,
  cover VARCHAR(255) NOT NULL,
  likes INTEGER NOT NULL,
  tags VARCHAR[],
  author_id INTEGER NOT NULL REFERENCES users(id)
);

CREATE TABLE posts (
    id serial PRIMARY KEY REFERENCES postmetadata(id),
    date TIMESTAMP NOT NULL,
    components JSONB NOT NULL
);

-- Insert sample user
INSERT INTO Users (username) VALUES ('John Corrigan');

-- Insert sample post metadata
INSERT INTO PostMetaData (slug, title, postedDate, cover, likes, tags, author_id)
VALUES ('sample-post-1', 'Sample Post 1', '2023-09-30', '/vue.webp', 10, '{"tag1", "tag2"}', 1);

-- Insert sample post content with components as JSONB
INSERT INTO Posts (id, date, components)
VALUES (1, NOW(), '[
    {"component": "PostSection", "props": {"heading": "Section 1", "body": "This is section 1 content."}},
    {"component": "PostImage", "props": {"src": "/vue.webp", "caption": "Image 1"}},
    {"component": "PostTextAndImage", "props": {"body": "Some text with an image", "src": "/vue.webp", "alt": "Image 2", "caption": "Image 2 caption"}},
    {"component": "PostCodeBlock", "props": {"code": "console.log('Hello, World!');", "language": "javascript"}},
    {"component": "PostSectionUl", "props": {"heading": "", "subheading": "Sublist", "items": ["Item 1", "Item 2", "Item 3"]}},
    {"component": "PostParagraph", "props": {"body": "This is a paragraph."}},
    {"component": "PostListMiddleOl", "props": {"items": ["Item A", "Item B", "Item C"]}}
]');

INSERT INTO PostMetaData (slug, title, postedDate, cover, likes, tags, author_id)
VALUES ('sample-post-2', 'Sample Post 2', '2023-09-30', '/vue.webp', 10, '{"tag1", "tag2"}', 1);

INSERT INTO Posts (id, date, components)
VALUES (2, NOW(), '[
    {"component": "PostSection", "props": {"heading": "Section 1", "body": "This is section 1 content."}},
    {"component": "PostImage", "props": {"src": "/vue.webp", "caption": "Image 1"}},
    {"component": "PostTextAndImage", "props": {"body": "Some text with an image", "src": "image2.jpg", "alt": "Image 2", "caption": "Image 2 caption"}},
    {"component": "PostCodeBlock", "props": {"code": "console.log('Hello, World!');", "language": "javascript"}},
    {"component": "PostSectionUl", "props": {"heading": "List Section", "subheading": "Sublist", "items": ["Item 1", "Item 2", "Item 3"]}},
    {"component": "PostParagraph", "props": {"body": "This is a paragraph."}},
    {"component": "PostListMiddleOl", "props": {"items": ["Item A", "Item B", "Item C"]}}
]');


