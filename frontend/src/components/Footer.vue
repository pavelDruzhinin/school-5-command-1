<template>
    <v-footer
            dense fixed app
            padless
    >
        <v-row
                justify="center"
                no-gutters
        >
            <v-btn
                    v-for="link in links"
                    :key="link"
                    color="white"
                    text
                    rounded
                    class="my-2"
            >
                {{ link }}
            </v-btn>
            <router-link to="/polls" style="text-decoration: none; color: white">
            <v-btn
                    color="white"
                    text
                    rounded
                    class="my-2"
            >
                All polls
            </v-btn>
            </router-link>
            <router-link to="/admin" style="text-decoration: none; color: white">
            <v-btn
                    color="white"
                    text
                    rounded
                    class="my-2"
            >
                Dashboard
            </v-btn>
            </router-link>
            <router-link to="/editpoll" style="text-decoration: none; color: white">
                <v-btn
                        color="white"
                        text
                        rounded
                        class="my-2"
                >
                    Edit
                </v-btn>
            </router-link>
            <v-col
                    class="py-4 text-center white--text"
                    cols="12"
            >
                {{ new Date().getFullYear() }} — <strong>PollsApp</strong>
            </v-col>
        </v-row>
    </v-footer>
</template>

<script>
    export default {
        data: () => ({}),
    }
</script>