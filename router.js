import Vue from 'vue'
import Router from 'vue-router'
import Index from "./src/components/Index"
import Polls from "./src/components/Polls"
import Admin from "./src/components/Admin"
import Test from "./src/components/Test"

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
            path: '/polls/',
            name: 'polls',
            component: Polls,
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
        }
    ]
})