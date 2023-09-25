<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditList from './EditUtils/EditList.vue';

const { modelValue } = defineProps({
    modelValue: {
        type: Object as () => { items: string[] },
        required: true
    }
})

const emit = defineEmits(['update:modelValue'])

const items = ref(modelValue.items)

const updateItems = (e: any) => {
    emit('update:modelValue', { items: e })
}

</script>

<template>
    <EditContainer label="Centered Ordered list" type="Centered Ordered list">
        <EditList v-on:update:modelValue="updateItems" label="Steps" v-model="items" />
    </EditContainer>
</template>