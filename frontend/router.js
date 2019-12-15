import Vue from 'vue'
import Router from 'vue-router'
import Index from "./src/components/Index"
import ChatBots from "./src/components/ChatBots"
import Admin from "./src/components/Admin"
import Test from "./src/components/Test"
import EditPoll from "./src/components/EditPoll"
import CardChat from "./src/components/CardChat"
import CreateBot from "./src/components/CreatBot"
import User from "./src/components/User"
import Adminuser from "./src/components/Adminuser"

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
            path: '/editpoll/:Pid',
            name: 'editpoll',
            component: EditPoll,
            props: true,
        },
        
        {
            path: '/cardchat/:Pid',
            name: 'cardchat',
            component: CardChat,
            props: true,
        },
        {
            path: '/User/:Pid',
            name: 'user',
            component: User,
            props: true,
        },
        {
            path: '/Adminuser/',
            name: 'adminuser',
            component: Adminuser,
            props: true,
        },
        {
            path:'/create/',
            name:'create',
            component:CreateBot,
            props:true,
        }
    ]
})