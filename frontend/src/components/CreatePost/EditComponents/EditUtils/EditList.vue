<script setup lang="ts">
import { ref } from 'vue'
import EditInput from './EditInput.vue';

const { modelValue, label } = defineProps({
    modelValue: {
        type: Array as () => string[],
        required: true
    },
    label: String
})

const items = ref(modelValue);

const emit = defineEmits(['update:modelValue'])

const addItem = () => {
    items.value.push("");
    emit('update:modelValue', items.value);
}

const removeItem = (index: number) => {
    items.value.splice(index, 1);
    emit('update:modelValue', items.value);
}

const updateItem = (e: any, index: number) => {
    items.value[index] = e;
    emit('update:modelValue', items.value);
}

</script>

<template>
    <div class="flex flex-col gap-5 w-full">
        <label class="text-white text-xl font-semibold">{{ label }}</label>
        <div class="w-full border-b-2"></div>
        <div class="w-full grid grid-cols-2 gap-5">
            <div v-for="(_, index) in modelValue" :key="index" class="w-full flex items-center justify-center gap-5">
                <EditInput v-on:update:modelValue="updateItem($event, index)" :label="'Item: ' + (index + 1)"
                    v-model="modelValue[index]" />
                <button @click="removeItem(index)"
                    class="opacity-60 hover:opacity-100 hover:scale-[1.02] active:scale-[0.97] duration-300"
                    type="button"><img src="/delete.svg" class="w-8 h-8" alt="delete" /></button>
            </div>
        </div>
        <div class="w-full flex items-center justify-center p-5">
            <button
                class="bg-blue-500 hover:bg-blue-600 active:scale-[0.97] text-white py-2 px-4 rounded-lg w-full max-w-[150px] duration-300"
                type="button" @click="addItem">Add
                Item</button>
        </div>
    </div>
</template>