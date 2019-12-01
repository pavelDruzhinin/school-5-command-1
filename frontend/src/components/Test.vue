<template>
    <div>
        <ul v-if="posts && posts.length">
            <li v-for="post in posts" :key="post">
                <p><strong>{{post.title}}</strong></p>
                <p>{{post.body}}</p>
            </li>
        </ul>

        <ul v-if="errors && errors.length">
            <li v-for="error in errors" :key="error">
                {{error.message}}
            </li>
        </ul>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data: () => ({
            posts: [],
            errors: []
        }),
// Запрос после создания компонента
        created() {
            axios.get(`https://jsonplaceholder.typicode.com/posts`)
                .then(response => {
// ответ json запихиваем в постс
                    this.posts = response.data;
                    window.console.log(this.posts)
                })
                .catch(e => {
                    this.errors.push(e)
                })
        }
    }

</script>