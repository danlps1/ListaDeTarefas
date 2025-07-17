import {createRouter, createWebHistory} from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: HomeView,
        },
        {
            path: '/usuarios',
            name: 'usuarios',
            component: () => import("@/views/UsuarioView.vue")
        },
        {
            path: '/tarefas',
            name: 'tarefas',
            component: () => import("@/views/TarefaView.vue")
        }
    ],
})

export default router
