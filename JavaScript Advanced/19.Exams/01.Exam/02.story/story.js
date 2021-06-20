class Story {
    constructor(title,creator){
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }else if(this._likes.length == 1) {
            return `${this._likes[0]} likes this story!`;
        }else {
            
            return `${this._likes[0]} and ${this._likes.length-1} others like this story!`
        }
    }

    like(username) {
        if (this._likes.some(x=>x == username)) {
            throw new Error('You can\'t like the same story twice!');
        } else if (username == this.creator) {
            throw new Error('You can\'t like your own story!')
        }
        this._likes.push(username);
        return `${username} liked ${this.title}!`
    }

    dislike(username) {
        if (!this._likes.some(x=>x == username)) {
            throw new Error(`You can't dislike this story!`);
        }
        let user = this._likes.find(x=>x.username == username);
        let index = this._likes.indexOf(user);
        this._likes.splice(index,1);
        return `${username} disliked ${this.title}`;
    }

    comment(username,content,id) {
        if (id === undefined || !this._comments.some(x=> x.id == id)) {
            let realId = this._comments.length == 0 ? 1 : this._comments.length + 1;
            this._comments.push({id:realId,username,content,replies: []});
            return `${username} commented on ${this.title}`;
        }
        let comment = this._comments.find(x=>x.id == id);
        let replyNumber = `${id}.${comment.replies.length + 1}`;
        let reply = {
            id: replyNumber,
            username: username,
            content: content,
        }
        comment.replies.push(reply);
        return 'You replied successfully';
    }

    toString(sortingType) {
        if (sortingType == 'asc') {
            this._comments.map(x=> {
                x.replies.sort((a,b) => Number(a.id) - Number(b.id))
            });
            this._comments.sort((a,b) => Number(a.id) - Number(b.id));
        }else if (sortingType == 'desc') {
            this._comments.map(x=> {
                x.replies.sort((a,b) => Number(b.id) - Number(a.id))
            });
            this._comments.sort((a,b) => Number(b.id) - Number(a.id));
        }else if (sortingType == 'username'){
            this._comments.map(x=> {
                x.replies.sort((a,b) => a.username.localeCompare(b.username))
            }).sort((a,b) => a.username.localeCompare(b.username));
            this._comments.sort((a,b)=>a.username.localeCompare(b.username));
        }
        let result = '';
        result += `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:\n`;
        for (const comment of this._comments) {
            result += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`;
            for (const reply of comment.replies) {
                result += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
            }
        }

        return result.trim();
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
