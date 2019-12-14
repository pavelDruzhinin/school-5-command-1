<template>
    <v-footer
            dense fixed app
            padless
    >
        <v-row
                justify="center"
                no-gutters
        >
            <router-link to="/bots" style="text-decoration: none; color: white">
            <v-btn
                    color="white"
                    text
                    rounded
                    class="my-2"
            >
                Chatbots
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
            <router-link to="/create" style="text-decoration: none; color: white">
                <v-btn
                        color="white"
                        text
                        rounded
                        class="my-2"
                >
                    Create Bot
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