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
            path: '/usuarios/cadastrar',
            name: 'cadastrarUsuario',
            component: () => import("@/views/Usuario/UsuarioCadastrarView.vue")
        },
        {
            path: `/usuarios/editar/:usuarioId`,
            name: 'editarUsuario',
            component: () => import("@/views/Usuario/UsuarioEditarView.vue")
        },
        {
            path: '/tarefas',
            name: 'tarefas',
            component: () => import("@/views/Tarefa/TarefaView.vue")
        },
        {
            path: '/tarefas/cadastrar',
            name: 'cadastrarTarefa',
            component: () => import("@/views/Tarefa/TarefaCadastrarView.vue")
        },
        {
            path: `/tarefas/editar/:tarefaId`,
            name: 'editarTarefa',
            component: () => import("@/views/Tarefa/TarefaEditarView.vue")
        },
    ],
})

export default router
