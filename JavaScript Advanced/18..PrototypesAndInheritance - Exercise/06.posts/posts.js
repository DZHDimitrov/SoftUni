function solution() {
    class Post {
        constructor(title,content) {
            this.title = title;
            this.content = content;
        }

        toString(){
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title,content,likes,dislikes){
            super(title,content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment){
            this.comments.push(comment);
        }

        toString() {
            let baseToString = super.toString();
            let commentsString = this.comments.map(x=> ` * ${x}`).join('\n');
            let fullCommentsString = this.comments.length > 0
            ? `\nComments:\n${commentsString}`
            : '';

            return `${baseToString}
Rating: ${this.likes - this.dislikes}${fullCommentsString}`;
        }
    }
    class BlogPost extends Post {
        constructor(title,content,views){
            super(title,content);
            this.views = views;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            return `${super.toString()}\nViews: ${this.views}`;
        }
    }
    return {Post,SocialMediaPost,BlogPost};
}

const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());
