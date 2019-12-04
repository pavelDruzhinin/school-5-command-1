import Vue from 'vue'
import Router from 'vue-router'
import Index from "./src/components/Index"
import ChatBots from "./src/components/ChatBots"
import Admin from "./src/components/Admin"
import Test from "./src/components/Test"
import EditPoll from "./src/components/EditPoll"
import CardChat from "./src/components/CardChat"

Vue.use(Router);

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            name: 'index',
            component: Index
        },
        {
            path: '/bots/',
            name: 'chatbots',
            component: ChatBots,
            props: true,
        },
        {
            path: '/admin/',
            name: 'admin',
            component: Admin,
            props: true,
        },
        {
            path: '/test/',
            name: 'test',
            component: Test,
            props: true,
        },

        {
            path: '/editpoll/',
            name: 'editpoll',
            component: EditPoll,
            props: true,
        },
        {
            path: '/cardchat/',
            name: 'cardchat',
            component: CardChat,
            props: true,
        }
    ]
})