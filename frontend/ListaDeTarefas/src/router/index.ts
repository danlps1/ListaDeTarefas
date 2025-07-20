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
            component: () => import("@/views/Usuario/UsuarioView.vue")
        },
        {
            path: '/tarefas',
            name: 'tarefas',
            component: () => import("@/views/Tarefa/TarefaView.vue")
        },
        {
            path: '/usuarios/cadastrar',
            name: 'CadastrarUsuario',
            component: () => import("@/views/Usuario/UsuarioCadastrarView.vue")
        }
    ],
})

export default router
