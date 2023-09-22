<script setup lang="ts">
import { defineEmits } from 'vue';
import ComponentPreview from './ComponentPreview.vue';
import { components } from '@/assets/components';

const { modal } = defineProps({
    modal: Boolean
});

const emit = defineEmits(['close', 'choose']);

const chooseComponent = (component: string | null | undefined) => {
    if (component) {
        emit('choose', component)
    }
    emit('close');
};

const closeModal = () => {
    emit('close');
};

</script>

<template>
    <div v-if="modal" @click="closeModal" class="bg-zinc-900 bg-opacity-60 z-0 fixed top-0 right-0 w-screen h-screen">
    </div>
    <div v-if="modal"
        class="overflow-y-scroll z-[50] rounded-lg w-2/3 h-2/3 max-w-2/3 max-h-2/3 fixed top-[16.67%] right-[16.67%] bg-zinc-200 p-5">
        <div class="grid componentPreviews gap-5">
            <ComponentPreview v-on:choose="chooseComponent" v-for="component in components" :componentPreview="component" />
        </div>
    </div>
</template>

<style scoped>
.componentPreviews {
    grid-template-columns: repeat(3, 1fr);
}
</style>