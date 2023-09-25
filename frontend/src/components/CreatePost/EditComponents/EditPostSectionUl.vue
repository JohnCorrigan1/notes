<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';
import EditList from './EditUtils/EditList.vue';

const { modelValue } = defineProps({
    modelValue: {
        type: Object as () => { heading: string, items: string[] },
        required: true
    }
})

const emit = defineEmits(['update:modelValue'])

const sectionHeader = ref(modelValue.heading)
const items = ref(modelValue.items)

const updateHeader = (e: any) => {
    emit('update:modelValue', { heading: e, items: items.value })
}

const updateItems = (e: any) => {
    emit('update:modelValue', { heading: sectionHeader.value, items: e })
}

</script>

<template>
    <EditContainer :label="sectionHeader" type="Section Unordered list">
        <EditInput v-on:update:modelValue="updateHeader" label="Section Header" v-model="sectionHeader" />
        <EditList v-on:update:modelValue="updateItems" label="Bullets" v-model="items" />
    </EditContainer>
</template>