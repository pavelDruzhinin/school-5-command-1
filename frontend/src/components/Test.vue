<template>
    <div>
        {{posts.components}}
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
            axios.get(`https://localhost:5001/swagger/v1/swagger.json`)
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